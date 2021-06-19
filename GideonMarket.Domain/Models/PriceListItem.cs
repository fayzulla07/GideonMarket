using GideonMarket.Entities.Shared;

namespace GideonMarket.Entities.Models
{
    public class PriceListItem : Entity
    {
        public int PriceId { get; private set; }
        public int ProductId { get; private set; }
        public decimal ManualPrice { get; private set; }
    }
}
