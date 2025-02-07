using FluentValidation;

namespace MasterNet.Application.Accounts.Register
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("El email no es correcto");
            RuleFor(x => x.Password).NotEmpty().WithMessage("La contraseña esta en blanco");
            RuleFor(x => x.NombreCompleto).NotEmpty().WithMessage("Ingrese su nombre completo");
            RuleFor(x => x.Username).NotEmpty().WithMessage("El nombre de usuario es obligatorio");
        }
    }
}