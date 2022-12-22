using BoostBusinessApi.Repository.Interface;
using System.Net;

namespace BoostBusinessApi.Extension
{
    public class ErrorReporterMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorReporterMiddleware> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public ErrorReporterMiddleware(ILogger<ErrorReporterMiddleware> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
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

                _unitOfWork.Rollback();
                _unitOfWork.SystemErroRepository.Add(systemError);
                await _unitOfWork.Commit();

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
