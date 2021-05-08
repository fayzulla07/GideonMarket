using GideonMarket.Domain.Exceptions;
using GideonMarket.Domain.Shared;
using GideonMarket.Utils;

namespace GideonMarket.Domain.Models
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
