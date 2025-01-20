using System.Net;
using System.Text.Json;
using MasterNet.Application.Core;

namespace MasterNet.WebApi.Middleware
{
    // Middleware para manejar excepciones globalmente
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger,
            IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Pasa la petición al siguiente middleware
                await _next(context);
            }
            catch (Exception ex)
            {
                // Loguea el error
                _logger.LogError(ex, ex.Message);

                // Configura la respuesta HTTP en caso de error
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Crea la respuesta según el entorno (detallada en desarrollo, genérica en producción)
                var response = _env.IsDevelopment()
                    ? new AppException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString()) // Captura el detalle tecnico del error
                    : new AppException(context.Response.StatusCode, "Internal Server Error");

                // Serializa la respuesta a JSON
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                var json = JsonSerializer.Serialize(response, options);    

                // Escribe el JSON en la respuesta
                await context.Response.WriteAsync(json);
            }
        }
    }
}