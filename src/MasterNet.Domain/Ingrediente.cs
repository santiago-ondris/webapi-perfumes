namespace MasterNet.Domain
{
    public class Ingrediente : EntidadBase
    {
        public string? Nombre {get; set;}
        public ICollection<Perfume>? Perfumes {get; set;}
        public ICollection<PerfumeIngrediente>? PerfumeIngredientes {get; set;}
    }
}