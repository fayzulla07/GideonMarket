using GideonMarket.Entities.Shared;


namespace GideonMarket.Entities.Models
{
    public class User : Entity, MainEntity
    {
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int RoleId { get; private set; }
        public Role UserRole { get; private set; }

        public User(string login, string email, int roleId)
        {
            Login = login;
            Email = email;
            RoleId = roleId;
        }
    }
}
