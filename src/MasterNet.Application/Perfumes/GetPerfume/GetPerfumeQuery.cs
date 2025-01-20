using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet.Application.Calificaciones.GetCalificaciones;
using MasterNet.Application.Core;
using MasterNet.Application.Fotos.GetFoto;
using MasterNet.Application.Ingredientes.GetIngredientes;
using MasterNet.Application.Precios.GetPrecios;
using MasterNet.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static MasterNet.Application.Perfumes.GetPerfume.GetPerfumeQuery;

namespace MasterNet.Application.Perfumes.GetPerfume
{
    public class GetPerfumeQuery
    {
        // Define la consulta para obtener un perfume específico por su Id
        public record GetPerfumeQueryRequest
        : IRequest<Result<PerfumeResponse>>
        {
            public Guid Id {get; set;}
        }        
    }

    // Handler que procesa la consulta
    internal class GetPerfumeQueryHandler
    : IRequestHandler<GetPerfumeQueryRequest, Result<PerfumeResponse>>
    {
        private readonly MasterNetDbContext _context;
        private readonly IMapper _mapper;

        public GetPerfumeQueryHandler(MasterNetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PerfumeResponse>> Handle(
            GetPerfumeQueryRequest request,
            CancellationToken cancellationToken
        )
        {
            // Consulta a la base de datos para obtener el perfume por Id
            var perfume = await _context.Perfumes!.Where(x => x.Id == request.Id)
                .Include(x => x.Ingredientes)
                .Include(x => x.Precios)
                .Include(x => x.Calificaciones)
                .ProjectTo<PerfumeResponse>(_mapper.ConfigurationProvider) // Mapea al modelo de respuesta
                .FirstOrDefaultAsync(cancellationToken);

                return Result<PerfumeResponse>.Success(perfume!);
        }
    }
    
    // Modelo de respuesta que encapsula los datos del perfume
    public record PerfumeResponse(
        Guid Id,
        string Nombre,
        string Descripcion,
        DateTime FechaPublicacion,
        List<IngredienteResponse> Ingredientes,
        List<CalificacionResponse> Calificaciones,
        List<PrecioResponse> Precios,
        List<FotoResponse> Fotos
    );
}