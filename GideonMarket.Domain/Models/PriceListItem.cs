using GideonMarket.Entities.Shared;

namespace GideonMarket.Entities.Models
{
    public class PriceListItem : Entity
    {
        public int PriceId { get; internal set; }
        public int ProductId { get; internal set; }
        public decimal ManualPrice { get; internal set; }

        public PriceListItem()
        {

        }
        public PriceListItem(int priceId, int productId, decimal manualPrice)
        {
            PriceId = priceId;
            ProductId = productId;
            ManualPrice = manualPrice;
        }
    }
}
