using MasterNet.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace MasterNet.Persistence
{
    public static class IdentitySeeder
    {
        public static async Task SeedRolesAndPoliciesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new Dictionary<string, List<string>>
            {
                ["Client"] = new()
                {
                    PolicyMaster.PERFUME_READ,
                    PolicyMaster.INGREDIENTE_READ,
                    PolicyMaster.COMENTARIO_READ,
                    PolicyMaster.COMENTARIO_CREATE
                },
                ["Admin"] = new()
                {
                    PolicyMaster.PERFUME_READ,
                    PolicyMaster.PERFUME_WRITE,
                    PolicyMaster.PERFUME_UPDATE,
                    PolicyMaster.PERFUME_DELETE,
                    PolicyMaster.INGREDIENTE_READ,
                    PolicyMaster.INGREDIENTE_CREATE,
                    PolicyMaster.INGREDIENTE_UPDATE,
                    PolicyMaster.COMENTARIO_READ,
                    PolicyMaster.COMENTARIO_CREATE,
                    PolicyMaster.COMENTARIO_DELETE
                }
            };

            foreach (var role in roles)
            {
                // Si el rol no existe, lo crea
                if (!await roleManager.RoleExistsAsync(role.Key))
                {
                    await roleManager.CreateAsync(new IdentityRole(role.Key));
                }

                var identityRole = await roleManager.FindByNameAsync(role.Key);
                var existingClaims = await roleManager.GetClaimsAsync(identityRole!);

                // Asignar solo las políticas que no estén ya asignadas
                foreach (var policy in role.Value)
                {
                    if (!existingClaims.Any(c => c.Type == CustomClaims.policies && c.Value == policy))
                    {
                        await roleManager.AddClaimAsync(identityRole!, new Claim(CustomClaims.policies, policy));
                    }
                }
            }
        }
    }
}
