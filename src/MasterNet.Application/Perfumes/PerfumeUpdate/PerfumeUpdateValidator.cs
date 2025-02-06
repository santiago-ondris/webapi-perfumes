using FluentValidation;

namespace MasterNet.Application.Perfumes.PerfumeUpdate
{
    public class PerfumeUpdateValidator : AbstractValidator<PerfumeUpdateRequest>
    {
        public PerfumeUpdateValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es requerido");
            RuleFor(x => x.Descripcion).NotEmpty().WithMessage("La descripcion no debe estar vacia");
            RuleFor(x => x.FechaPublicacion).NotEmpty().WithMessage("La fecha de publicacion es requerida");
        }
    }
}