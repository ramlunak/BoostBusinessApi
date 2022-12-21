using BoostBusinessApi.Data;
using BoostBusinessApi.Repository;
using BoostBusinessApi.Repository.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigureServicies(builder);

var app = builder.Build();

ConfigureSwagger(app);

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

    builder.Services.AddAutoMapper(typeof(Program));
}

static void ConfigureSwagger(WebApplication app)
{
    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
    app.UseSwagger();
    app.UseSwaggerUI();
    //}
}

