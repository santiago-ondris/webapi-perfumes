namespace MasterNet.Domain
{
    public class Calificacion : EntidadBase
    {
        public string? Usuario {get; set;}
        public int Puntaje {get; set;}
        public string? Comentario {get; set;}
        public Guid? PerfumeId {get; set;}
        public Perfume? Perfume {get; set;}
    }
}