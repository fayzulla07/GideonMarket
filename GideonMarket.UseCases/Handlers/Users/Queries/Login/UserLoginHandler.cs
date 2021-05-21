using GideonMarket.UseCases.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Users.Queries
{
    internal class UserLoginHandler : IRequestHandler<UserLoginRequest, UserLoginDto>
    {
        private readonly IAppContext context;
        public UserLoginHandler(IAppContext context)
        {
            this.context = context;
        }
        public async Task<UserLoginDto> Handle(UserLoginRequest request, CancellationToken cancellationToken)
        {
            var user = await context.Users.Where(x => x.Login == request.UserName && x.Password == request.Password).Include(x => x.UserRole).FirstOrDefaultAsync();
            if(user != null)
            {
                UserLoginDto userLogin = new UserLoginDto();
                userLogin.Id = user.Id;
                userLogin.Login = user.Login;
                userLogin.Email = user.Email;
                userLogin.RoleName = user.UserRole?.Name;
                return userLogin;
            }
            else
            {
                return null;
            }
            
        }
    }
}
