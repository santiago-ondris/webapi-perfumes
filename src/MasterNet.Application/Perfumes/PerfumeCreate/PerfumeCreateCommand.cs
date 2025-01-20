// Clase que representa al command y al commandhandler

using FluentValidation;
using MasterNet.Application.Core;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Perfumes.PerfumeCreate
{
    public class PerfumeCreateCommand
    {
        // Define el comando para crear un perfume
        public record PerfumeCreateCommandRequest(PerfumeCreateRequest perfumeCreateRequest)
        : IRequest<Result<Guid>>;

        // Handler que procesa la creación de un perfume
        internal class PerfumeCreateCommandHandler
        : IRequestHandler<PerfumeCreateCommandRequest, Result<Guid>>
        {
            private readonly MasterNetDbContext _context;
            public PerfumeCreateCommandHandler(MasterNetDbContext context)
            {
                _context = context;
            }
            public async Task<Result<Guid>> Handle(PerfumeCreateCommandRequest request, CancellationToken cancellationToken)
            {
                // Crea una nueva entidad Perfume con los datos del request
                var perfume = new Perfume {
                    Id = Guid.NewGuid(),
                    Nombre = request.perfumeCreateRequest.Nombre,
                    Descripcion = request.perfumeCreateRequest.Descripcion,
                    FechaPublicacion = request.perfumeCreateRequest.FechaPublicacion
                };

                // Añade la entidad a la base de datos
                _context.Add(perfume);

                // Guarda los cambios y verifica si la operación fue exitosa
                var resultado = await _context.SaveChangesAsync(cancellationToken) > 0;

                return resultado
                    ? Result<Guid>.Success(perfume.Id)
                    : Result<Guid>.Failure("Error al crear el perfume");

            }
        }
        
        // Validador para el comando de creación de perfumes
        public class PerfumeCreateCommandRequestValidator : AbstractValidator<PerfumeCreateCommandRequest>
        {
            public PerfumeCreateCommandRequestValidator()
            {
                RuleFor(x => x.perfumeCreateRequest).SetValidator(new PerfumeCreateValidator());
            }
        }
    }
}