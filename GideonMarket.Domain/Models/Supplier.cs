using GideonMarket.Entities.Shared;


namespace GideonMarket.Entities.Models
{
    public class Supplier : Entity, MainEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public Supplier()
        {

        }
        public Supplier(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}
