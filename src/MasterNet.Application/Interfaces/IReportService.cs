using MasterNet.Domain;

namespace MasterNet.Application.Interfaces
{
    public interface IReportService<T> where T : EntidadBase
    {
        Task<MemoryStream> GetCsvReport(List<T> records);
    }
}