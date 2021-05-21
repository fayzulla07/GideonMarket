using GideonMarket.Entities.Exceptions;
using GideonMarket.Entities.Shared;


namespace GideonMarket.Entities.Models
{
    public class Client : Entity, MainEntity
    {
        public string FullName { get; }
        public string Email { get; }

        public Client()
        {

        }
        public Client(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}
