using GideonMarket.Domain.Shared;

namespace GideonMarket.Domain.Models
{
    public class Product : Entity, MainEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int? ProductTypeId { get; private set; }
        public int UnitId { get; private set; }
        public decimal Price { get; private set; }

        public Product()
        {

        }
        public Product(string name, string description, int? productTypeId, int unitId, decimal price)
        {
            Name = name;
            Description = description;
            ProductTypeId = productTypeId;
            UnitId = unitId;
            Price = price;
        }

        public void SetPrice(decimal price)
        {
            Price = price;
        }
    }
}
