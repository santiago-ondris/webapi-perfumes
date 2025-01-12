// La clase request para crear un perfume

using Microsoft.AspNetCore.Http;

namespace MasterNet.Application.Perfumes.PerfumeCreate
{
    public class PerfumeCreateRequest
    {
        public string? Nombre {get; set;}
        public string? Descripcion {get; set;}
        public DateTime? FechaPublicacion {get; set;}
        public IFormFile? Foto {get; set;}
        public Guid? IngredienteId {get; set;}
        public Guid? PrecioId {get; set;}
    }
}