using GideonMarket.Domain.Shared;


namespace GideonMarket.Domain.Models
{
    public class User : Entity, MainEntity
    {
        public string Login { get; private set; }
        public string Email { get; private set; }

        public User(string login, string email)
        {
            Login = login;
            Email = email;
        }
    }
}
