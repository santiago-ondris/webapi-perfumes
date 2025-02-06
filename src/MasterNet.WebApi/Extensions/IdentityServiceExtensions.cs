using System.Text;
using MasterNet.Application.Interfaces;
using MasterNet.Infrastructure.Security;
using MasterNet.Persistence;
using MasterNet.Persistence.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace MasterNet.WebApi.Extensions
{
    // Clase de extension para agregar servicios relacionados con la identidad (Identity) a la coleccion de servicios de la aplicación.
    public static class IdentityServiceExtensions
    {
        /// <summary>
        /// Metodo de extension para configurar e inyectar los servicios de Identity en la aplicacion.
        /// </summary>
        /// <param name="services">La coleccion de servicios en la que se agregarán los servicios de identidad.</param>
        /// <param name="configuration">Objeto de configuracion de la aplicación, que puede ser utilizado para acceder a valores de configuracion.</param>
        /// <returns>Devuelve la coleccion de servicios actualizada, permitiendo el encadenamiento de metodos.</returns>
        public static IServiceCollection AddIdentityServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            // Configuracion de Identity para el usuario (AppUsuario):
            services.AddIdentityCore<AppUsuario>(opt => {
                opt.Password.RequireNonAlphanumeric = false; // La contraseña no necesita caracteres especiales
                opt.User.RequireUniqueEmail = true; // Cada usuario debe tener un email unico
            })
            .AddRoles<IdentityRole>() // Se habilita el soporte para roles de usuario
            .AddEntityFrameworkStores<MasterNetDbContext>(); // Se utiliza MasterNetDbContext para el almacenamiento de datos de Identity

            // Inyección de dependencias:
            // Se registra el servicio para la generación de tokens (ITokenService) y su implementación (TokenService)
            // asi como el servicio de acceso a la informacion del usuario (IUserAccessor).
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserAccessor, UserAccessor>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]!));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt => {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Se retorna la coleccion de servicios modificada para continuar con el registro de otros servicios.
            return services;
        }
    }
}
