using MasterNet.Application.Interfaces;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Perfumes.PerfumeReporteExcel
{
    public class PerfumeReporteExcelQuery
    {
        public record PerfumeReporteExcelQueryRequest : IRequest<MemoryStream>;

        internal class PerfumeReporteExcelQueryHandler : IRequestHandler<PerfumeReporteExcelQueryRequest, MemoryStream>
        {
            private readonly MasterNetDbContext _context;
            private readonly IReportService<Perfume> _reporteService;

            public PerfumeReporteExcelQueryHandler(
                MasterNetDbContext context,
                IReportService<Perfume> reporteService
            )
            {
                _context = context;
                _reporteService = reporteService;
            }

            public async Task<MemoryStream> Handle(PerfumeReporteExcelQueryRequest request, CancellationToken cancellationToken)
            {
                var perfumes = await _context.Perfumes!.Take(3).Skip(0).ToListAsync();

                return await _reporteService.GetCsvReport(perfumes);
            }
        }
    }
}