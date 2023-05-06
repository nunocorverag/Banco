using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Banco.Server.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Agregar configuración para la conexión a la base de datos
builder.Configuration.AddJsonFile("appsettings.json");
var connectionString = builder.Configuration.GetConnectionString("BancoContext");

builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();
builder.Services.AddCors(options =>{
    options.AddPolicy(name: "MyCors", builder => {
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
        .AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("MyCors");
app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();