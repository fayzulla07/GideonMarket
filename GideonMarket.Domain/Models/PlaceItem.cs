using GideonMarket.Entities.Shared;

namespace GideonMarket.Entities.Models
{
    public class PlaceItem : Entity
    {
        public int PlaceId { get; private set; }
        public int ProductId { get; private set; }
        public double RemainCount { get; private set; }

        public PlaceItem()
        {

        }
        public PlaceItem(int placeId, int productId)
        {
            PlaceId = placeId;
            ProductId = productId;
        }

        public void AddCount(double count)
        {
            RemainCount = RemainCount + count;
        }
        public void ReduceCount(double count)
        {
            RemainCount = RemainCount - count;
        }

    }
}
