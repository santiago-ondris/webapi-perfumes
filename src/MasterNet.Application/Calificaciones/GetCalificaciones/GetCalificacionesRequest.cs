using MasterNet.Application.Core;

namespace MasterNet.Application.Calificaciones.GetCalificaciones
{
    public class GetCalificacionesRequest : PagingParams
    {
        public string? Usuario {get; set;}
        public Guid? PerfumeId {get; set;}
    }
}