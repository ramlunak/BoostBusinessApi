using BoostBusinessApi.Data;
using BoostBusinessApi.Repository;
using BoostBusinessApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

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

    builder.Services.AddDbContext<DBContext>(opciones => opciones.UseSqlite("name=SQliteDbConnection"));

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

