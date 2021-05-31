using GideonMarket.Entities.Exceptions;
using GideonMarket.Entities.Shared;


namespace GideonMarket.Entities.Models
{
    public class Customers : Entity, MainEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public Customers()
        {

        }
        public Customers(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}
