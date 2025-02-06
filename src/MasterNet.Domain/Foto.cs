namespace MasterNet.Domain
{
    public class Foto : EntidadBase
    {
        public string? Url {get; set;}
        public Guid? PerfumeId {get; set;}
        public Perfume? Perfume {get; set;}
        public string? PublicId {get; set;}
    }
}