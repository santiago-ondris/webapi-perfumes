namespace MasterNet.Domain
{
    public class Perfume : EntidadBase
    {
        public string? Nombre {get; set;}
        public string? Descripcion {get; set;}
        public DateTime? FechaPublicacion {get; set;}
        public ICollection<Calificacion>? Calificaciones {get; set;}
        public ICollection<Precio>? Precios {get; set;}
        public ICollection<PerfumePrecio>? PerfumePrecios {get; set;}
        public ICollection<Ingrediente>? Ingredientes {get; set;}
        public ICollection<PerfumeIngrediente>? PerfumeIngredientes {get; set;}
        public ICollection<Foto>? Fotos {get; set;}
    }
}