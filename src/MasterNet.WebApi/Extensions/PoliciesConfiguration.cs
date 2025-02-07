using MasterNet.Domain;

namespace MasterNet.WebApi.Extensions
{
    public static class PoliciesConfiguration
    {
        public static IServiceCollection AddPoliciesServices(
            this IServiceCollection services
        )
        {
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(
                    PolicyMaster.PERFUME_READ, policy => policy.RequireAssertion(
                        context => context.User.HasClaim(
                            c => c.Type == CustomClaims.policies && c.Value == PolicyMaster.PERFUME_READ
                            ))
                );
                opt.AddPolicy(
                    PolicyMaster.PERFUME_WRITE, policy => policy.RequireAssertion(
                        context => context.User.HasClaim(
                            c => c.Type == CustomClaims.policies && c.Value == PolicyMaster.PERFUME_WRITE
                            ))
                );
                opt.AddPolicy(
                    PolicyMaster.PERFUME_UPDATE, policy => policy.RequireAssertion(
                        context => context.User.HasClaim(
                            c => c.Type == CustomClaims.policies && c.Value == PolicyMaster.PERFUME_UPDATE
                            ))
                );
                opt.AddPolicy(
                    PolicyMaster.PERFUME_DELETE, policy => policy.RequireAssertion(
                        context => context.User.HasClaim(
                            c => c.Type == CustomClaims.policies && c.Value == PolicyMaster.PERFUME_DELETE
                            ))
                );

                opt.AddPolicy(
                    PolicyMaster.INGREDIENTE_CREATE, policy => policy.RequireAssertion(
                        context => context.User.HasClaim(
                            c => c.Type == CustomClaims.policies && c.Value == PolicyMaster.INGREDIENTE_CREATE
                            ))
                );
                opt.AddPolicy(
                    PolicyMaster.INGREDIENTE_UPDATE, policy => policy.RequireAssertion(
                        context => context.User.HasClaim(
                            c => c.Type == CustomClaims.policies && c.Value == PolicyMaster.INGREDIENTE_UPDATE
                            ))
                );
                opt.AddPolicy(
                    PolicyMaster.INGREDIENTE_READ, policy => policy.RequireAssertion(
                        context => context.User.HasClaim(
                            c => c.Type == CustomClaims.policies && c.Value == PolicyMaster.INGREDIENTE_READ
                            ))
                );
                opt.AddPolicy(
                    PolicyMaster.COMENTARIO_READ, policy => policy.RequireAssertion(
                        context => context.User.HasClaim(
                            c => c.Type == CustomClaims.policies && c.Value == PolicyMaster.COMENTARIO_READ
                            ))
                );
                opt.AddPolicy(
                    PolicyMaster.COMENTARIO_CREATE, policy => policy.RequireAssertion(
                        context => context.User.HasClaim(
                            c => c.Type == CustomClaims.policies && c.Value == PolicyMaster.COMENTARIO_CREATE
                            ))
                );
                opt.AddPolicy(
                    PolicyMaster.COMENTARIO_DELETE, policy => policy.RequireAssertion(
                        context => context.User.HasClaim(
                            c => c.Type == CustomClaims.policies && c.Value == PolicyMaster.COMENTARIO_DELETE
                            ))
                );
            }
            );

            return services;
        }
    }
}