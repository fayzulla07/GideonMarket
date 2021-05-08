using GideonMarket.Domain.Exceptions;
using GideonMarket.Domain.Shared;


namespace GideonMarket.Domain.Models
{
    public class Client : Entity, MainEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }


        public Client(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}
