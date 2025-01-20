using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet.Application.Core;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Ingredientes.GetIngredientes
{
    public class GetIngredientesQuery
    {
        public record GetIngredientesQueryRequest
        : IRequest<Result<PagedList<IngredienteResponse>>>
        {
            public GetIngredientesRequest? IngredienteRequest {get; set;}
        }

        internal class GetIngredientesQueryHandler
        : IRequestHandler<GetIngredientesQueryRequest, Result<PagedList<IngredienteResponse>>>
        {
            private readonly MasterNetDbContext _context;
            private readonly IMapper _mapper;

            public GetIngredientesQueryHandler(MasterNetDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<IngredienteResponse>>> Handle(
                GetIngredientesQueryRequest request,
                CancellationToken cancellationToken)
            {
                IQueryable<Ingrediente> queryable = _context.Ingredientes!;

                var predicate = ExpressionBuilder.New<Ingrediente>();
                if(!string.IsNullOrEmpty(request.IngredienteRequest!.Nombre))
                {
                    predicate = predicate.And(x => x.Nombre!.Contains(request.IngredienteRequest.Nombre));
                }

                if(!string.IsNullOrEmpty(request.IngredienteRequest.OrderBy))
                {
                    Expression<Func<Ingrediente, object>>? orderBySelector =
                    request.IngredienteRequest.OrderBy.ToLower() switch 
                    {
                        "nombre" => ingrediente => ingrediente.Nombre!,
                        _ => ingrediente => ingrediente.Nombre!
                    };

                    bool orderBy = request.IngredienteRequest.OrderAsc.HasValue
                                    ? request.IngredienteRequest.OrderAsc.Value
                                    : true;
                    queryable = orderBy
                                ? queryable.OrderBy(orderBySelector)
                                : queryable.OrderByDescending(orderBySelector);
                }

                queryable = queryable.Where(predicate);

                var ingredientesQuery = queryable
                                        .ProjectTo<IngredienteResponse>(_mapper.ConfigurationProvider)
                                        .AsQueryable();
                
                var pagination = await PagedList<IngredienteResponse>
                                .CreateAsync(ingredientesQuery,
                                request.IngredienteRequest.PageNumber,
                                request.IngredienteRequest.PageSize
                                );

                return Result<PagedList<IngredienteResponse>>.Success(pagination);
            }
        }
    }

    public record IngredienteResponse(
        Guid? Id,
        string? Nombre
    )
    {
        public IngredienteResponse() : this(null, null)
        {
        }
    }
}