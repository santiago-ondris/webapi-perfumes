using Microsoft.AspNetCore.Identity;

namespace MasterNet.Persistence.Models
{
    public class AppUsuario : IdentityUser
    {
        public string? NombreCompleto {get; set;}
        public string? Nacionalidad {get; set;}
    }
}