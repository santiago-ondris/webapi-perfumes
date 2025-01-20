using MasterNet.Application.Core;

namespace MasterNet.Application.Ingredientes.GetIngredientes
{
    public class GetIngredientesRequest : PagingParams
    {
        public string? Nombre {get; set;}
    }
}