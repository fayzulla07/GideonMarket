using GideonMarket.Entities.Exceptions;
using GideonMarket.Entities.Shared;
using GideonMarket.Utils;

namespace GideonMarket.Entities.Models
{
    public class Unit: Entity, MainEntity
    {
        public string Name { get; private set; }
        public Unit()
        {
        }
        public Unit(string name)
        {
            Name = name;
        }
        public Unit(int id, string name)
        {
            Id = Id;
            Name = name;
        }
        public override void Validate()
        {
            if (Name.IsEmpty())
                throw new EntityException($"{nameof(Unit)}.{nameof(Name)} пусто!");
        }

    }
}
