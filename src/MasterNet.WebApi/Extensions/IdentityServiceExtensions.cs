using System.Text;
using MasterNet.Application.Interfaces;
using MasterNet.Infrastructure.Security;
using MasterNet.Persistence;
using MasterNet.Persistence.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MasterNet.WebApi.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Configura Identity para el usuario (AppUsuario)
            services.AddIdentityCore<AppUsuario>(options =>
            {
                options.Password.RequireNonAlphanumeric = false; // No se requieren caracteres especiales
                options.User.RequireUniqueEmail = true;           // Cada usuario debe tener un email único
            })
            .AddRoles<IdentityRole>() // Se habilita el soporte para roles
            .AddEntityFrameworkStores<MasterNetDbContext>(); // Usa MasterNetDbContext para el almacenamiento

            // Inyecta los servicios para la generación de tokens y acceso al usuario
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserAccessor, UserAccessor>();

            // Configuración del token JWT
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]!));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                    // Configuración del evento OnForbidden para retornar un mensaje personalizado
                    options.Events = new JwtBearerEvents
                    {
                        OnForbidden = async context =>
                        {
                            context.Response.StatusCode = 403;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync("{\"message\":\"Debes ser tipo ADMIN\"}");
                        }
                    };
                });

            return services;
        }
    }
}
