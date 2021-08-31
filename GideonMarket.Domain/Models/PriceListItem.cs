using GideonMarket.Entities.Shared;

namespace GideonMarket.Entities.Models
{
    public class PriceListItem : Entity
    {
        public int PriceId { get; private set; }
        public int ProductId { get; private set; }
        public decimal ManualPrice { get; private set; }

        public PriceListItem()
        {

        }
        public PriceListItem(int priceId, int productId, decimal manualPrice)
        {
            PriceId = priceId;
            ProductId = productId;
            ManualPrice = manualPrice;
        }

        public void Update(int priceId, int productId, decimal manualPrice)
        {
            PriceId = priceId;
            ProductId = productId;
            ManualPrice = manualPrice;
        }
    }
}
