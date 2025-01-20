// Archivo contenedor de dependencias
using MasterNet.Application;
using MasterNet.Application.Interfaces;
using MasterNet.Infrastructure.Reports;
using MasterNet.Persistence;
using MasterNet.Persistence.Models;
using MasterNet.WebApi.Extensions;
using MasterNet.WebApi.Middleware;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args); // Instancia de la aplicacion
builder.Services.AddApplication(); // Builder para la aplicacion
builder.Services.AddPersistence(builder.Configuration); // Builder para la persistencia

builder.Services.AddScoped(typeof(IReportService<>), typeof(ReportService<>)); // Builder para los reportes

builder.Services.AddControllers(); // Builder para los controladores
builder.Services.AddEndpointsApiExplorer(); // Builder para la documentacion de la API
builder.Services.AddSwaggerGen(); // Builder para la generacion de la documentacion de la API

builder.Services.AddIdentityCore<AppUsuario>(opt => {
    opt.Password.RequireNonAlphanumeric = false;
    opt.User.RequireUniqueEmail = true;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<MasterNetDbContext>(); // Builder para la autenticacion de usuarios

var app = builder.Build(); // Instancia de la aplicacion

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>(); // Middleware para el manejo de excepciones
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.SeedDataAuthentication(); // Inicializacion de la autenticacion

app.MapControllers(); // Mapeo de los controladores
app.Run(); // Ejecucion de la aplicacion

