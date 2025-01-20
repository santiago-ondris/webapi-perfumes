using MasterNet.Application.Ingredientes.GetIngredientes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Ingredientes.GetIngredientes.GetIngredientesQuery;

namespace MasterNet.WebApi.Controllers
{
    [ApiController]
    [Route("api/ingredientes")]
    public class IngredientesController : ControllerBase
    {
        private readonly ISender _sender;

        public IngredientesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult> PaginationIngrediente
        (
            [FromQuery] GetIngredientesRequest request,
            CancellationToken cancellationToken
        )
        {
            var query = new GetIngredientesQueryRequest
            {
                IngredienteRequest = request
            };
            var resultados = await _sender.Send(query, cancellationToken);
            return resultados.IsSuccess ? Ok(resultados.Value) : NotFound();
        }
    }
}