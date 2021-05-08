using GideonMarket.Domain.Exceptions;
using GideonMarket.Domain.Shared;

namespace GideonMarket.Domain.Models
{
    public class Product : Entity, MainEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int? ProductTypeId { get; private set; }
        public int UnitId { get; private set; }

        public ProductType ProductType { get; private set; }
        public Unit  Unit { get; private set; }

        public Product(string name, string description, int? productTypeId, int unitId)
        {
            Name = name;
            Description = description;
            ProductTypeId = productTypeId;
            UnitId = unitId;
        }
    }
}
