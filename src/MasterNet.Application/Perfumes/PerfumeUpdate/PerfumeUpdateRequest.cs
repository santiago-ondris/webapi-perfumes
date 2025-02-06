using Bogus.DataSets;

namespace MasterNet.Application.Perfumes.PerfumeUpdate
{
    public class PerfumeUpdateRequest
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }
}