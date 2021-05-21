using GideonMarket.Entities.Exceptions;
using GideonMarket.Entities.Shared;
using GideonMarket.Utils;

namespace GideonMarket.Entities.Models
{
    public class ProductType: Entity, MainEntity
    {
        public string Name { get; private set; }

        public ProductType(string name)
        {
            Name = name;
            Validate();
        }

        public ProductType(int id, string name)
        {
            Id = id;
            Name = name;
            Validate();
        }

        public override void Validate()
        {
            if (Name.IsEmpty())
                throw new EntityException($"{nameof(ProductType)}.{nameof(Name)} пусто!");
        }
    }
}
