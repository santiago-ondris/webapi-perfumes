using System.Security.Claims;
using MasterNet.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace MasterNet.Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccesor;

        public UserAccessor(IHttpContextAccessor httpContextAccesor)
        {
            _httpContextAccesor = httpContextAccesor;
        }

        public string GetUsername()
        {
            return _httpContextAccesor.HttpContext!.User.FindFirstValue(ClaimTypes.Name)!;
        }
        public string GetEmail()
        {
            return _httpContextAccesor.HttpContext!.User.FindFirstValue(ClaimTypes.Email)!;
        }
    }

}