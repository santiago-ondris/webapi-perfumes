// Esta clase valida el contenido del request

using FluentValidation;

namespace MasterNet.Application.Perfumes.PerfumeCreate
{
    public class PerfumeCreateValidator : AbstractValidator<PerfumeCreateRequest>
    {
        public PerfumeCreateValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre del perfume es requerido");
            RuleFor(x => x.Descripcion).NotEmpty().WithMessage("La descripción del perfume es requerida");
        }
    }
}