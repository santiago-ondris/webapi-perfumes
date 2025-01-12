using MasterNet.Application.Perfumes.PerfumeCreate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Perfumes.PerfumeCreate.PerfumeCreateCommand;
using static MasterNet.Application.Perfumes.PerfumeReporteExcel.PerfumeReporteExcelQuery;

namespace MasterNet.WebApi.Controllers
{
    [ApiController]
    [Route("api/perfumes")]
    public class PerfumesController : ControllerBase
    {
        private readonly ISender _sender;
        public PerfumesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> PerfumeCreate([FromForm] PerfumeCreateRequest request, CancellationToken cancellationToken)
        {
            var command = new PerfumeCreateCommandRequest(request);
            var resultado = await _sender.Send(command, cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("reporte")]
        public async Task<IActionResult> ReporteCSV(CancellationToken cancellationToken)
        {
            var query = new PerfumeReporteExcelQueryRequest();
            var resultado = await _sender.Send(query, cancellationToken);
            byte[] excelBytes = resultado.ToArray();
            return File(excelBytes, "text/csv", "perfumes.csv");
        }
    }
}