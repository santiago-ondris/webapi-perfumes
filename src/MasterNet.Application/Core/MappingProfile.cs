using AutoMapper;
using MasterNet.Application.Calificaciones.GetCalificaciones;
using MasterNet.Application.Fotos.GetFoto;
using MasterNet.Application.Ingredientes.GetIngredientes;
using MasterNet.Application.Perfumes.GetPerfume;
using MasterNet.Application.Precios.GetPrecios;
using MasterNet.Domain;

namespace MasterNet.Application.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Perfume, PerfumeResponse>();
            CreateMap<Foto, FotoResponse>();
            CreateMap<Precio, PrecioResponse>();
            CreateMap<Ingrediente, IngredienteResponse>();
            CreateMap<Calificacion, CalificacionResponse>()
                .ForMember(dest => dest.NombrePerfume, src => src.MapFrom(doc => doc.Perfume!.Nombre));
        }
    }
}