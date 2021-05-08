using GideonMarket.Domain.Shared;

namespace GideonMarket.Domain.Models
{
    public class PlaceItem : Entity
    {
        public int PlaceId { get; private set; }
        public int ProductId { get; private set; }
        public double RemainCount { get; private set; }
        public Product Product { get; private set; }

        public PlaceItem(int placeId, int productId, double remainCount)
        {
            PlaceId = placeId;
            ProductId = productId;
            RemainCount = remainCount;
        }
    }
}
