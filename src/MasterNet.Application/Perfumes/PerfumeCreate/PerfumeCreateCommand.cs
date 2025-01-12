// Clase que representa al command y al commandhandler

using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Perfumes.PerfumeCreate
{
    public class PerfumeCreateCommand
    {
        public record PerfumeCreateCommandRequest(PerfumeCreateRequest perfumeCreateRequest)
        : IRequest<Guid>;

        internal class PerfumeCreateCommandHandler
        : IRequestHandler<PerfumeCreateCommandRequest, Guid>
        {
            private readonly MasterNetDbContext _context;
            public PerfumeCreateCommandHandler(MasterNetDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(PerfumeCreateCommandRequest request, CancellationToken cancellationToken)
            {
                var perfume = new Perfume {
                    Id = Guid.NewGuid(),
                    Nombre = request.perfumeCreateRequest.Nombre,
                    Descripcion = request.perfumeCreateRequest.Descripcion,
                    FechaPublicacion = request.perfumeCreateRequest.FechaPublicacion
                };

                _context.Add(perfume);

                await _context.SaveChangesAsync(cancellationToken);

                return perfume.Id;
            }
        }
    }
}