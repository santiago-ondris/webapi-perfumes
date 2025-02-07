// Esta clase valida el contenido del request

using FluentValidation;

namespace MasterNet.Application.Perfumes.PerfumeCreate
{
    public class PerfumeCreateValidator : AbstractValidator<PerfumeCreateRequest>
    {
        public PerfumeCreateValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre esta vacio");
            RuleFor(x => x.Descripcion).NotEmpty().WithMessage("La descripcion no puede ser nula");
        }
    }
}