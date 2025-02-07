using FluentValidation;
using MasterNet.Application.Core;
using MasterNet.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Perfumes.PerfumeDelete
{
    public class PerfumeDeleteCommand
    {
        public record PerfumeDeleteCommandRequest(Guid? PerfumeId)
        : IRequest<Result<Unit>>, ICommandBase;

        internal class PerfumeDeleteCommandHandler
        : IRequestHandler<PerfumeDeleteCommandRequest, Result<Unit>>
        {
            private readonly MasterNetDbContext _context;

            public PerfumeDeleteCommandHandler(MasterNetDbContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(
                        PerfumeDeleteCommandRequest request,
                        CancellationToken cancellationToken)
            {
                var perfume = await _context.Perfumes!
                .Include(x => x.Ingredientes)
                .Include(x => x.Precios)
                .Include(x => x.Calificaciones)
                .Include(x => x.Fotos)
                .FirstOrDefaultAsync(x => x.Id == request.PerfumeId);

                if(perfume is null)
                {
                    return Result<Unit>.Failure("El perfume no existe");
                }

                _context.Perfumes!.Remove(perfume);

                var resultado = await _context.SaveChangesAsync(cancellationToken) > 0;

                return resultado  
                        ? Result<Unit>.Success(Unit.Value)
                        : Result<Unit>.Failure("No se pudo eliminar el perfume");
            }
        }
    
        public class PerfumeDeleteCommandRequestValidator
        : AbstractValidator<PerfumeDeleteCommandRequest>
        {
            public PerfumeDeleteCommandRequestValidator()
            {
                RuleFor(x => x.PerfumeId)
                    .NotNull().WithMessage("El id del perfume no puede ser nulo");
            }
        }
    }
}
