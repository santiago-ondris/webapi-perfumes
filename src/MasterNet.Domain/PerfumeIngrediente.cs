namespace MasterNet.Domain
{
    public class PerfumeIngrediente
    {
        public Guid? PerfumeId {get; set;}
        public Perfume? Perfume {get; set;}
        public Guid? IngredienteId {get; set;}
        public Ingrediente? Ingrediente {get; set;}
    }
}