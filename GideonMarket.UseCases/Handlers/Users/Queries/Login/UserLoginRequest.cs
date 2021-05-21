using MediatR;

namespace GideonMarket.UseCases.Handlers.Users.Queries
{
    public class UserLoginRequest: IRequest<UserLoginDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
