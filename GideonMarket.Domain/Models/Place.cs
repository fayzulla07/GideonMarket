using GideonMarket.Entities.Enums;
using GideonMarket.Entities.Shared;
using System.Collections.Generic;
using System.Linq;

namespace GideonMarket.Entities.Models
{
    public class Place : Entity, MainEntity
    {
        public string Name { get; private set; }
        public PlaceType PlaceType { get; private set; }
        public List<PlaceItem> PlaceItems { get; private set; }

        public Place()
        {

        }
        public Place(string name, PlaceType placeType)
        {
            Name = name;
            PlaceType = placeType;
        }
        public void AddProductToPlace(int productId, double remainCount)
        {
             if (PlaceItems != null && PlaceItems.Where(x => x.ProductId == productId).Any())
             {
                UpdateItemByProductId(productId, remainCount);
             }
            else
            {
                AddItemByProductId(productId, remainCount);
            }
        }
        private void AddItemByProductId(int productId, double remainCount)
        {
            var placeitem = new PlaceItem(Id, productId);
            placeitem.AddCount(remainCount);
            if(PlaceItems == null)
            {
                PlaceItems = new List<PlaceItem>();
            }
            PlaceItems.Add(placeitem);
        }
        private void UpdateItemByProductId(int productId, double remainCount)
        {
            foreach (var item in PlaceItems)
            {
                if(item.ProductId == productId)
                {
                    item.AddCount(remainCount);
                    break;
                }
            }
        }
    }
}
