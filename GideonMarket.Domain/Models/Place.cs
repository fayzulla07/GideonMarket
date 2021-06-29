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

        #region Shared Modules
        public void AddCount(int productId, double count)
        {
            if (PlaceItems == null || !PlaceItems.Any())
            {
                CreateItem(productId);
            }
            foreach (var item in PlaceItems)
            {
                if (item.ProductId == productId)
                {
                    item.AddCount(count);
                    break;
                }
            }
        }
        public void ReduceCount(int productId, double count)
        {
            foreach (var item in PlaceItems)
            {
                if (item.ProductId == productId)
                {
                    item.ReduceCount(count);
                    break;
                }
            }
        }
        private void CreateItem(int productId)
        {
            var placeitem = new PlaceItem(Id, productId);
            if (PlaceItems == null)
            {
                PlaceItems = new List<PlaceItem>();
            }
            PlaceItems.Add(placeitem);
        }
        #endregion



    }
}
