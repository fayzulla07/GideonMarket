using GideonMarket.Entities.Enums;
using GideonMarket.Entities.Shared;
using System.Collections.Generic;

namespace GideonMarket.Entities.Models
{
    public class Place : Entity, MainEntity
    {
        public string Name { get;  }
        public PlaceType PlaceType { get; }
        public List<PlaceItem> PlaceItems { get; }

        public Place(string name, PlaceType placeType)
        {
            Name = name;
            PlaceType = placeType;
        }
        public void AddItem(PlaceItem placeItem)
        {
            PlaceItems.Add(placeItem);
        }
    }
}
