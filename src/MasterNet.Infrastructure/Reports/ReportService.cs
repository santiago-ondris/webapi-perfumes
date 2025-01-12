using System.Globalization;
using CsvHelper;
using MasterNet.Application.Interfaces;
using MasterNet.Domain;

namespace MasterNet.Infrastructure.Reports
{
    public class ReportService<T> : IReportService<T> where T : EntidadBase
    {
        public Task<MemoryStream> GetCsvReport(List<T> records)
        {
            using var memoryStream = new MemoryStream();
            using var textWriter = new StreamWriter(memoryStream);
            using var CsvWriter = new CsvWriter(textWriter, CultureInfo.InvariantCulture);

            CsvWriter.WriteRecords(records);
            textWriter.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin); // Resetea los bytes en memoria

            return Task.FromResult(memoryStream);
        }
    }
}