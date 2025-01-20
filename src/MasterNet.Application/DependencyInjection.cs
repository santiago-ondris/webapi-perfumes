using FluentValidation;
using FluentValidation.AspNetCore;
using MasterNet.Application.Core;
using MasterNet.Application.Perfumes.PerfumeCreate;
using Microsoft.Extensions.DependencyInjection;

namespace MasterNet.Application
{
    // Clase para configurar la inyección de dependencias de la aplicación
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services
        )
        {
            // Configura MediatR para manejar comandos y consultas
            services.AddMediatR(configuration =>
            {
              configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            // Configura FluentValidation para la validación automática
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<PerfumeCreateCommand>();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services; // Devuelve el IServiceCollection modificado
        }
    }
}