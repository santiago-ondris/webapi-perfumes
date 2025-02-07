namespace MasterNet.Application.Accounts.Register
{
    public class RegisterRequest
    {
        public string? NombreCompleto {get; set;}
        public string? Username {get; set;}
        public string? Email {get; set;}
        public string? Password {get; set;}
    }
}