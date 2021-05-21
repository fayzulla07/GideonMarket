using GideonMarket.Entities.Shared;

namespace GideonMarket.Entities.Models
{
    public class Role : Entity, MainEntity
    {
        public string Name { get; set; }
        public Role()
        {

        }
        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
