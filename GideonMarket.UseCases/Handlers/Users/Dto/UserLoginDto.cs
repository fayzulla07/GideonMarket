

namespace GideonMarket.UseCases.Handlers.Users
{
    public class UserLoginDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}
