namespace MasterNet.Domain
{
    public class Precio : EntidadBase
    {
        public string? Nombre {get; set;}
        public decimal PrecioActual {get; set;}
        public decimal PrecioPromocion {get; set;}
        public ICollection<Perfume>? Perfumes {get; set;}
        public ICollection<PerfumePrecio>? PerfumePrecios {get; set;}
    }
}