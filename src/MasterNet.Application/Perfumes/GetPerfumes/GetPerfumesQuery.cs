using System.Linq.Expressions; 
using AutoMapper; 
using AutoMapper.QueryableExtensions; 
using MasterNet.Application.Core; 
using MasterNet.Application.Perfumes.GetPerfume;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Perfumes.GetPerfumes
{
    // Clase para la consulta para obtener perfumes
    public class GetPerfumesQuery
    {
        // Record que representa la solicitud para obtener una lista paginada de perfumes
        public record GetPerfumesQueryRequest : IRequest<Result<PagedList<PerfumeResponse>>>
        {
            public GetPerfumesRequest? PerfumesRequest {get; set;}
        }

        // Clase que maneja la logica de la consulta
        internal class GetPerfumesQueryHandler
        : IRequestHandler<GetPerfumesQueryRequest, Result<PagedList<PerfumeResponse>>>
        {
            private readonly MasterNetDbContext _context;
            private readonly IMapper _mapper;

            public GetPerfumesQueryHandler(MasterNetDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            // Metodo que maneja la solicitud para obtener perfumes
            public async Task<Result<PagedList<PerfumeResponse>>> Handle(
                GetPerfumesQueryRequest request,
                CancellationToken cancellationToken)
            {
                // Consulta base para obtener perfumes e incluir propiedades relacionadas
                IQueryable<Perfume> queryable = _context.Perfumes!
                                                .Include(x => x.Ingredientes) 
                                                .Include(x => x.Calificaciones) 
                                                .Include(x => x.Precios);

                // Construcción dinamica de filtros usando expresiones
                var predicate = ExpressionBuilder.New<Perfume>();

                // Filtra por nombre si esta especificado
                if (!string.IsNullOrEmpty(request.PerfumesRequest!.Nombre))
                {
                    predicate = predicate
                        .And(y => y.Nombre!.ToLower()
                        .Contains(request.PerfumesRequest.Nombre!.ToLower()));
                }

                // Filtra por descripcion si está especificada
                if (!string.IsNullOrEmpty(request.PerfumesRequest!.Descripcion))
                {
                    predicate = predicate
                        .And(y => y.Descripcion!.ToLower()
                        .Contains(request.PerfumesRequest.Descripcion!.ToLower()));
                }

                // Aplica ordenamiento si se especifica un campo para ordenar
                if (!string.IsNullOrEmpty(request.PerfumesRequest!.OrderBy))
                {
                    // Selector para el campo de ordenamiento
                    Expression<Func<Perfume, object>>? orderBySelector =
                                     request.PerfumesRequest.OrderBy!.ToLower() switch
                                     {
                                        "nombre" => perfume => perfume.Nombre!, 
                                        "descripcion" => perfume => perfume.Descripcion!,
                                        _ => perfume => perfume.Nombre! // Valor por defecto: ordenar por nombre
                                     };

                    // Determina el orden ascendente o descendente (por defecto, ascendente)
                    bool orderBy = request.PerfumesRequest.OrderAsc.HasValue
                                    ? request.PerfumesRequest.OrderAsc.Value
                                    : true;

                    // Aplica el orden a la consulta
                    queryable = orderBy
                                ? queryable.OrderBy(orderBySelector)
                                : queryable.OrderByDescending(orderBySelector);                 
                }

                // Aplica el filtro dinámico a la consulta
                queryable = queryable.Where(predicate);

                // Proyecta la consulta a objetos PerfumeResponse usando AutoMapper
                var perfumesQuery = queryable
                            .ProjectTo<PerfumeResponse>(_mapper.ConfigurationProvider)
                            .AsQueryable();

                // Aplica paginacion a la consulta proyectada
                var pagination = await PagedList<PerfumeResponse>.CreateAsync(
                    perfumesQuery,
                    request.PerfumesRequest!.PageNumber, 
                    request.PerfumesRequest.PageSize 
                );

                return Result<PagedList<PerfumeResponse>>.Success(pagination);                                               
            }
        }
    }
}
