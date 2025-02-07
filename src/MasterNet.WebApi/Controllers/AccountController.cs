using System.Net;
using MasterNet.Application.Accounts;
using MasterNet.Application.Accounts.GetCurrentUser;
using MasterNet.Application.Accounts.Login;
using MasterNet.Application.Accounts.Register;
using MasterNet.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Accounts.GetCurrentUser.GetCurrentUserQuery;
using static MasterNet.Application.Accounts.Login.LoginCommand;
using static MasterNet.Application.Accounts.Register.RegisterCommand;

namespace MasterNet.WebApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IUserAccessor _user;

        public AccountController(ISender sender, IUserAccessor user)
        {
            _sender = sender;
            _user = user;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Profile>> Login(
            [FromBody] LoginRequest request,
            CancellationToken cancellationToken
        )
        {
            var command = new LoginCommandRequest(request);
            var resultado = await _sender.Send(command, cancellationToken); 
            return resultado.IsSuccess ? Ok(resultado.Value) : Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Profile>> Register(
            [FromBody] RegisterRequest request,
            CancellationToken cancellationToken
        )
        {
            var command = new RegisterCommandRequest(request);
            var resultado = await _sender.Send(command, cancellationToken);
            return resultado.IsSuccess ? Ok(resultado.Value) : Unauthorized();
        }

        [Authorize]
        [HttpGet("me")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Profile>> Me(CancellationToken cancellationToken)
        {
            var email = _user.GetEmail();
            var request = new GetCurrentUserRequest {Email = email};
            var query = new GetCurrentUserQueryRequest(request);
            var resultado = await _sender.Send(query, cancellationToken);
            return resultado.IsSuccess ? Ok(resultado.Value) : Unauthorized();
        }
    }
}