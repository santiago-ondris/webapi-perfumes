// Clase que representa al command y al commandhandler

using FluentValidation;
using MasterNet.Application.Core;
using MasterNet.Application.Interfaces;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            private readonly IPhotoService _fotoService;
            public PerfumeCreateCommandHandler(MasterNetDbContext context, IPhotoService fotoService)
            {
                _context = context;
                _fotoService = fotoService;
            }
            public async Task<Result<Guid>> Handle(PerfumeCreateCommandRequest request, CancellationToken cancellationToken)
            {
                // Crea una nueva entidad Perfume con los datos del request
                var perfumeId = Guid.NewGuid();
                var perfume = new Perfume {
                    Id = perfumeId,
                    Nombre = request.perfumeCreateRequest.Nombre,
                    Descripcion = request.perfumeCreateRequest.Descripcion,
                    FechaPublicacion = request.perfumeCreateRequest.FechaPublicacion
                };

                // Si el request tiene una foto, la sube al servicio de fotos y la añade a la entidad
                if(request.perfumeCreateRequest.Foto is not null)
                {
                    var photoUploadResult = await _fotoService.AddPhoto(request.perfumeCreateRequest.Foto);

                    var imagen = new Foto
                    {
                        Id = Guid.NewGuid(),
                        Url = photoUploadResult.Url,
                        PublicId = photoUploadResult.PublicId,
                        PerfumeId = perfume.Id
                    };

                    perfume.Fotos = new List<Foto>{imagen};
                }

                if(request.perfumeCreateRequest.IngredienteId is not null)
                {
                    var ingrediente = _context.Ingredientes!.FirstOrDefault(x => x.Id == request.perfumeCreateRequest.IngredienteId);
                    if(ingrediente is null)
                    {
                        return Result<Guid>.Failure("No se encontró el ingrediente");
                    }

                    perfume.Ingredientes = new List<Ingrediente> {ingrediente};
                }

                if(request.perfumeCreateRequest.PrecioId is not null)
                {
                    var precio = await _context.Precios!.FirstOrDefaultAsync(x => x.Id == request.perfumeCreateRequest.PrecioId);
                    if(precio is null)
                    {
                        return Result<Guid>.Failure("No se encontró el precio");
                    }

                    perfume.Precios = new List<Precio> {precio};
                }

                // Añade la entidad a la memoria de entity framework
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