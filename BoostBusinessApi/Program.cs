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

static void ConfigureSwagger(WebApplication app)
{
    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
    app.UseSwagger();
    app.UseSwaggerUI();
    //}
}

static void ConfigureServicies(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<DBContext>(opciones =>
        opciones.UseSqlServer("name=DefaultConnection"));

    builder.Services.AddTransient<IDBTransaction, DBTransaction>();
    builder.Services.AddTransient<IUserRepository, UserRepository>();

    builder.Services.AddAutoMapper(typeof(Program));
}
