using Bogus;
using MasterNet.Domain;
using MasterNet.Persistence;
using MasterNet.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.WebApi.Extensions
{
    public static class DataSeed
    {
        public static async Task SeedDataAuthentication(
            this IApplicationBuilder app
        )
        {
            using var scope = app.ApplicationServices.CreateScope();
            var service = scope.ServiceProvider;
            var loggerFactory = service.GetRequiredService<ILoggerFactory>();

            try {
                var context = service.GetRequiredService<MasterNetDbContext>();
                await context.Database.MigrateAsync();
                var userManager = service.GetRequiredService<UserManager<AppUsuario>>();

                if(!userManager.Users.Any())
                {
                    var usuarioAdmin = new AppUsuario {
                        NombreCompleto = "Santiago Ondris",
                        UserName = "santiondris",
                        Email = "santiagonicolas2001@gmail.com"
                    };

                    await userManager.CreateAsync(usuarioAdmin, "Password123$");
                    await userManager.AddToRoleAsync(usuarioAdmin, CustomRoles.ADMIN);

                    var usuarioCliente = new AppUsuario {
                        NombreCompleto = "Julian Figueroa",
                        UserName = "julanfigueroa",
                        Email = "julifigue@gmail.com"
                    };

                    await userManager.CreateAsync(usuarioCliente, "Password123$");
                    await userManager.AddToRoleAsync(usuarioCliente, CustomRoles.CLIENT);                    
                }

                var perfumes = await context.Perfumes!.Take(3).Skip(0).ToListAsync();
                if(!context.Set<PerfumeIngrediente>().Any())
                {
                    var ingredientes = await context.Ingredientes!.Take(2).Skip(0).ToListAsync();

                    foreach(var perfume in perfumes)
                    {
                        perfume.Ingredientes = ingredientes;
                    }
                }
                if(!context.Set<PerfumePrecio>().Any())
                {
                    var precios = await context.Precios!.ToListAsync();

                    foreach(var perfume in perfumes)
                    {
                        perfume.Precios = precios;
                    }
                }
                if(!context.Set<Calificacion>().Any())

                {
                    foreach(var perfume in perfumes)
                    {
                        var fakerCalificacion = new Faker<Calificacion>()
                        .RuleFor(c => c.Id, _ => Guid.NewGuid())
                        .RuleFor(c => c.Usuario, f => f.Name.FullName())
                        .RuleFor(c => c.Comentario, f => f.Commerce.ProductDescription())
                        .RuleFor(c => c.Puntaje, 5)
                        .RuleFor(c => c.PerfumeId, perfume.Id);

                        var calificaciones = fakerCalificacion.Generate(3);
                        context.AddRange(calificaciones);
                    }
                }
                await context.SaveChangesAsync();
            } catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<MasterNetDbContext>();
                logger.LogError(e.Message);
            }
        }
    }
}