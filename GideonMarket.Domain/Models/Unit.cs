using GideonMarket.Domain.Exceptions;
using GideonMarket.Domain.Shared;
using GideonMarket.Utils;

namespace GideonMarket.Domain.Models
{
    public class Unit: Entity, MainEntity
    {
        public string Name { get; private set; }
        public Unit(string name)
        {
            Name = name;
        }
        public override void Validate()
        {
            if (Name.IsEmpty())
                throw new EntityException($"{nameof(Unit)}.{nameof(Name)} пусто!");
        }

    }
}
