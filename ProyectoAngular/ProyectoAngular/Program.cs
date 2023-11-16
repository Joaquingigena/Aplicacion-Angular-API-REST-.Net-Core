using Microsoft.EntityFrameworkCore;
using ProyectoAngular.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Hago la conexion a la base de datos
builder.Services.AddDbContext<DbangularContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

// Acitvo Cors para evitar un problema entre la url de la api y de angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

//Cambio esto por lo de abajo
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//Por esto, para poder usar la interfaz de swaggers
app.UseSwagger();
app.UseSwaggerUI();

//Uso el Cors
app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
