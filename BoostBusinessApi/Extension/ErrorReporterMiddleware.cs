using Azure.Core;
using BoostBusinessApi.Repository.Interface;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Text.Json;

namespace BoostBusinessApi.Extension
{
    public class ErrorReporterMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorReporterMiddleware> _logger;
        private readonly ISystemErroRepository _erroRepository;
        public ErrorReporterMiddleware(ILogger<ErrorReporterMiddleware> logger, ISystemErroRepository erroRepository)
        {
            _logger = logger;
            _erroRepository = erroRepository;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                context.Request.EnableBuffering();
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var systemError = ex.AsSystemError();
                systemError.Method = context.Request.Method;
                systemError.Path = context.Request.Path.ToString();

                using var reader = new StreamReader(context.Request.Body);
                var body = await reader.ReadToEndAsync();

                _erroRepository.Add(systemError);
                await _erroRepository.SaveChangesAsync();

                var problem = new
                {
                    Code = systemError.Id,
                    Method = $"{systemError.Method} - {systemError.Path}",
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server Erro",
                    ex.Message
                };

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(problem.AsJson());

            }
        }
    }
}
