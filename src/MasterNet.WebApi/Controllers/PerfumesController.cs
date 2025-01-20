using MasterNet.Application.Core;
using MasterNet.Application.Perfumes.GetPerfume;
using MasterNet.Application.Perfumes.GetPerfumes;
using MasterNet.Application.Perfumes.PerfumeCreate;
using MasterNet.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Perfumes.GetPerfume.GetPerfumeQuery;
using static MasterNet.Application.Perfumes.GetPerfumes.GetPerfumesQuery;
using static MasterNet.Application.Perfumes.PerfumeCreate.PerfumeCreateCommand;
using static MasterNet.Application.Perfumes.PerfumeReporteExcel.PerfumeReporteExcelQuery;

namespace MasterNet.WebApi.Controllers
{
    [ApiController]
    [Route("api/perfumes")]
    public class PerfumesController : ControllerBase
    {
        // Controlador de perfumes
        private readonly ISender _sender;
        public PerfumesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult> PaginationCursos(
            [FromQuery] GetPerfumesRequest request,
            CancellationToken cancellationToken
        )
        {
            var query = new GetPerfumesQueryRequest {PerfumesRequest = request};
            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
        }

        [HttpPost("create")]
        // Creacion de un perfume
        public async Task<ActionResult<Result<Guid>>> PerfumeCreate(
            [FromForm] PerfumeCreateRequest request,
            CancellationToken cancellationToken)
        {
            var command = new PerfumeCreateCommandRequest(request);
            return await _sender.Send(command, cancellationToken);            
        }
        
        [HttpGet("{id}")]
        // Obtener un perfume por su Id
        public async Task<IActionResult> PerfumeGet(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetPerfumeQueryRequest { Id = id };
            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();
        }

        [HttpGet("reporte")]
        // Descarga de reporte en formato CSV de perfumes
        public async Task<IActionResult> ReporteCSV(CancellationToken cancellationToken)
        {
            var query = new PerfumeReporteExcelQueryRequest();
            var resultado = await _sender.Send(query, cancellationToken);
            byte[] excelBytes = resultado.ToArray();
            return File(excelBytes, "text/csv", "perfumes.csv");
        }
    }
}