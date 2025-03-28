using MasterNet.Application.Perfumes.DTOs;

namespace MasterNet.Application.Interfaces
{
    public interface IPerfumeDapperRepository
    {
        Task<List<PerfumeDapperDto>> ObtenerPerfumesAsync();
    }
}
