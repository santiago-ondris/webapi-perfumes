namespace MasterNet.Application.Fotos.GetFoto
{
    public record FotoResponse(
        Guid? Id,
        string? Url,
        Guid? PerfumeId
    )
    {
        public FotoResponse() : this(null, null, null)
        {
            
        }
    }
}