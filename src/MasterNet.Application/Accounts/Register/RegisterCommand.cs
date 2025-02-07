using FluentValidation;
using MasterNet.Application.Core;
using MasterNet.Application.Interfaces;
using MasterNet.Persistence.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Accounts.Register
{
    public class RegisterCommand
    {
        public record RegisterCommandRequest(RegisterRequest registerRequest)
        : IRequest<Result<Profile>>, ICommandBase;

        internal class RegisterCommandHandler
        : IRequestHandler<RegisterCommandRequest, Result<Profile>>
        {
            private readonly UserManager<AppUsuario> _userManager;
            private readonly ITokenService _tokenService;

            public RegisterCommandHandler(
                UserManager<AppUsuario> userManager,
                ITokenService tokenService)
            {
                _userManager = userManager;
                _tokenService = tokenService;
            }

            public async Task<Result<Profile>> Handle(
                RegisterCommandRequest request,
                CancellationToken cancellationToken)
            {
                if(await _userManager.Users.AnyAsync(x => x.Email == request.registerRequest.Email))
                {
                    return Result<Profile>.Failure("El email ya se encuentra registrado");
                }
                if(await _userManager.Users.AnyAsync(x => x.UserName == request.registerRequest.Username))
                {
                    return Result<Profile>.Failure("El nombre de usuario ya se encuentra registrado");
                }

                var user = new AppUsuario
                {
                    NombreCompleto = request.registerRequest.NombreCompleto,
                    Id = Guid.NewGuid().ToString(),
                    Email = request.registerRequest.Email,
                    UserName = request.registerRequest.Username
                };

                var resultado = await _userManager.CreateAsync(user, request.registerRequest.Password!);

                if(resultado.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Client");

                    var profile = new Profile
                    {
                        Email = user.Email,
                        NombreCompleto = user.NombreCompleto,
                        Token = await _tokenService.CreateToken(user),
                        Username = user.UserName
                    };

                    return Result<Profile>.Success(profile);
                }

                return Result<Profile>.Failure("Errores en el registro del usuario");                
            }
        }

        public class RegisterCommandRequestValidator : AbstractValidator<RegisterCommandRequest>
        {
            public RegisterCommandRequestValidator()
            {
                RuleFor(x => x.registerRequest).SetValidator(new RegisterValidator());
            }
        }
    }
}