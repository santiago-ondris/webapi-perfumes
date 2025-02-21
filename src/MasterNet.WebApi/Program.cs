// Archivo contenedor de dependencias
using MasterNet.Application;
using MasterNet.Application.Interfaces;
using MasterNet.Infrastructure.Photos;
using MasterNet.Infrastructure.Reports;
using MasterNet.Persistence;
using MasterNet.WebApi.Extensions;
using MasterNet.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args); // Instancia de la aplicacion
builder.Services.AddApplication(); // Builder para la aplicacion
builder.Services.AddPersistence(builder.Configuration); // Builder para la persistencia
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddPoliciesServices();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection(nameof(CloudinarySettings))); // Builder para la configuracion de Cloudinary
builder.Services.AddScoped<IPhotoService, PhotoService>(); // Builder para el servicio de fotos

builder.Services.AddScoped(typeof(IReportService<>), typeof(ReportService<>)); // Builder para los reportes
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers(); // Builder para los controladores

builder.Services.AddSwaggerDocumentation();

builder.Services.AddCors(o => o.AddPolicy("corsapp", builder => {
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build(); // Instancia de la aplicacion

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>(); // Middleware para el manejo de excepciones
app.UseSwaggerDocumentation();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("corsapp");

await app.SeedDataAuthentication(); // Inicializacion de la autenticacion

app.MapControllers(); // Mapeo de los controladores
app.Run(); // Ejecucion de la aplicacion

