using GideonMarket.Domain.Exceptions;
using GideonMarket.Domain.Shared;


namespace GideonMarket.Domain.Models
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
