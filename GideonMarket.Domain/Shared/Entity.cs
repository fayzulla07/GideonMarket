
namespace GideonMarket.Domain.Shared
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public virtual void Validate() { }
    }
}
