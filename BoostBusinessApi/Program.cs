using BoostBusinessApi.Data;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Extension;
using BoostBusinessApi.Repository;
using BoostBusinessApi.Repository.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigureServicies(builder);

var app = builder.Build();

//app.Use((context, next) =>
//{
//    context.Request.EnableBuffering();
//    return next();
//});

app.UseMiddleware<ErrorReporterMiddleware>();
//app.UseErrorHandler();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureServicies(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<DBContext>(opciones => opciones.UseSqlServer("name=DefaultConnection"));

    builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

    builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
    builder.Services.AddTransient<ISystemErroRepository, SystemErroRepository>();

    builder.Services.AddAutoMapper(typeof(Program));

    builder.Services.AddTransient<ErrorReporterMiddleware>();
}


