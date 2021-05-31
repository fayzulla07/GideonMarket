using GideonMarket.Entities.Shared;


namespace GideonMarket.Entities.Models
{
    public class Customer : Entity, MainEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public Customer()
        {

        }
        public Customer(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}
