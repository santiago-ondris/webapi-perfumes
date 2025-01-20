using System.Globalization;
using CsvHelper;
using MasterNet.Application.Interfaces;
using MasterNet.Domain;

namespace MasterNet.Infrastructure.Reports
{
    public class ReportService<T> : IReportService<T> where T : EntidadBase
    {
        // Metodo para obtener un reporte en formato CSV
        public Task<MemoryStream> GetCsvReport(List<T> records)
        {
            using var memoryStream = new MemoryStream(); // Stream de memoria para el archivo CSV
            using var textWriter = new StreamWriter(memoryStream); // StreamWriter para escribir en el archivo CSV
            using var CsvWriter = new CsvWriter(textWriter, CultureInfo.InvariantCulture);

            CsvWriter.WriteRecords(records);
            textWriter.Flush(); // Limpia el StreamWriter
            memoryStream.Seek(0, SeekOrigin.Begin); // Resetea los bytes en memoria

            return Task.FromResult(memoryStream);
        }
    }
}