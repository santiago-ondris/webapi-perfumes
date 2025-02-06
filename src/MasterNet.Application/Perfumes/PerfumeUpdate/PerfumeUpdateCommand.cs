using FluentValidation;
using MasterNet.Application.Core;
using MasterNet.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Perfumes.PerfumeUpdate
{
    public class PerfumeUpdateCommand
    {
        public record PerfumeUpdateCommandRequest(
            PerfumeUpdateRequest PerfumeUpdateRequest, Guid? PerfumeId
            ) : IRequest<Result<Guid>>;

        internal class PerfumeUpdateCommandHandler
            : IRequestHandler<PerfumeUpdateCommandRequest, Result<Guid>>
        {
            private readonly MasterNetDbContext _context;
            public PerfumeUpdateCommandHandler(MasterNetDbContext context)
            {
                _context = context;
            }

            public async Task<Result<Guid>> Handle(
                PerfumeUpdateCommandRequest request,
                CancellationToken cancellationToken)
            {
                var perfumeId = request.PerfumeId;

                var perfume = await _context.Perfumes!.FirstOrDefaultAsync(x => x.Id == perfumeId);

                if (perfume is null)
                {
                    return Result<Guid>.Failure("El perfume no existe");
                }

                perfume.Nombre = request.PerfumeUpdateRequest.Nombre;
                perfume.Descripcion = request.PerfumeUpdateRequest.Descripcion;
                perfume.FechaPublicacion = request.PerfumeUpdateRequest.FechaPublicacion;

                _context.Entry(perfume).State = EntityState.Modified;
                var resultado = await _context.SaveChangesAsync() > 0;

                return resultado
                    ? Result<Guid>.Success(perfume.Id)
                    : Result<Guid>.Failure("No se pudo actualizar el perfume");
            }
        }

        public class PerfumeUpdateCommandValidator : AbstractValidator<PerfumeUpdateCommandRequest>
        {
            public PerfumeUpdateCommandValidator()
            {
                RuleFor(x => x.PerfumeUpdateRequest).SetValidator(new PerfumeUpdateValidator());
                RuleFor(x => x.PerfumeId).NotNull();
            }
        }
    }
}