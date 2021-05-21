using GideonMarket.Web.Server.IdentityServer;
using GideonMarket.Web.Server.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GideonMarket.UseCases.Handlers.Users.Queries;
namespace GideonMarket.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        AuthService _service;
        private readonly IMediator mediator;

        public AuthController(AuthService service, IMediator mediator)
        {
            _service = service;
            this.mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await mediator.Send(new UserLoginRequest() { UserName = model.UserName, Password = model.Password });
                if(user == null)
                    return StatusCode(401, new { errors = "Имя или пароль не верны. Попробуйте еще раз!" });
                UserResponse response = _service.Login(user);
                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
