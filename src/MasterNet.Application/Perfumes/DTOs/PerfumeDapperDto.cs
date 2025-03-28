namespace MasterNet.Application.Perfumes.DTOs
{
    public class PerfumeDapperDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaPublicacion { get; set; }
    }
}