namespace MasterNet.Domain
{
    public class PerfumePrecio
    {
        public Guid? PerfumeId {get; set;}
        public Perfume? Perfume {get; set;}
        public Guid? PrecioId {get; set;}
        public Precio? Precio {get; set;}        
    }
}