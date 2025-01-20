using MasterNet.Application.Core;

namespace MasterNet.Application.Perfumes.GetPerfumes
{
    public class GetPerfumesRequest : PagingParams
    {
        public string? Nombre {get; set;}
        public string? Descripcion {get; set;}
    }
}