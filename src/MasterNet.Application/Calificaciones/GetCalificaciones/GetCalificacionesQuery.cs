using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet.Application.Core;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Calificaciones.GetCalificaciones
{
    public class GetCalificacionesQuery
    {
        public record GetCalificacionesQueryRequest
        : IRequest<Result<PagedList<CalificacionResponse>>>
        {
            public GetCalificacionesRequest? CalificacionesRequest {get; set;}
        }

        internal class GetCalificacionesQueryHandler
        : IRequestHandler<GetCalificacionesQueryRequest, Result<PagedList<CalificacionResponse>>>
        {
            private readonly MasterNetDbContext _context;
            private readonly IMapper _mapper;

            public GetCalificacionesQueryHandler(MasterNetDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<CalificacionResponse>>> Handle(
                GetCalificacionesQueryRequest request,
                CancellationToken cancellationToken)
            {
                IQueryable<Calificacion> queryable = _context.Calificaciones!;

                var predicate = ExpressionBuilder.New<Calificacion>();

                if(!string.IsNullOrEmpty(request.CalificacionesRequest!.Usuario))
                {
                    predicate = predicate.And(x => x.Usuario!.Contains(request.CalificacionesRequest.Usuario));
                }

                if(request.CalificacionesRequest.PerfumeId is not null)
                {
                    predicate = predicate.And(x => x.PerfumeId == request.CalificacionesRequest.PerfumeId);
                }

                if(!string.IsNullOrEmpty(request.CalificacionesRequest.OrderBy))
                {
                    Expression<Func<Calificacion, object>>? orderBySelector =
                        request.CalificacionesRequest.OrderBy.ToLower() switch
                        {
                            "Usuario" => usuario => usuario.Usuario!,
                            "NombrePerfume" => perfume => perfume.Id!,
                            _ => x => x.Usuario!
                        }; 

                        bool orderBy = request.CalificacionesRequest.OrderAsc.HasValue
                            ? request.CalificacionesRequest.OrderAsc.Value
                            : true;

                        queryable = orderBy
                            ? queryable.OrderBy(orderBySelector)
                            : queryable.OrderByDescending(orderBySelector);
                }

                queryable = queryable.Where(predicate);

                var calificacionQuery = queryable
                    .ProjectTo<CalificacionResponse>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                var pagination = await PagedList<CalificacionResponse>.CreateAsync(
                    calificacionQuery,
                    request.CalificacionesRequest.PageNumber,
                    request.CalificacionesRequest.PageSize
                );

                return Result<PagedList<CalificacionResponse>>.Success(pagination);
            }
        }
    }

    public record CalificacionResponse(
        string? Usuario,
        int? Puntaje,
        string? Comentario,
        string? NombrePerfume
    )
    {
        public CalificacionResponse() : this(null, null, null, null)
        {
        }
    }
}