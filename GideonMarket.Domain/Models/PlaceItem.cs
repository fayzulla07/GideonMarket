﻿using GideonMarket.Domain.Shared;

namespace GideonMarket.Domain.Models
{
    public class PlaceItem : Entity
    {
        public int PlaceId { get; private set; }
        public int ProductId { get; private set; }
        public double RemainCount { get; private set; }

        public PlaceItem()
        {

        }
        public PlaceItem(int placeId, int productId, double remainCount)
        {
            PlaceId = placeId;
            ProductId = productId;
            RemainCount = remainCount;
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
