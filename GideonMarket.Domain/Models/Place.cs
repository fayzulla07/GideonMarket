using GideonMarket.Entities.Enums;
using GideonMarket.Entities.Shared;
using System.Collections.Generic;

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
        public void AddItem(PlaceItem placeItem)
        {
            PlaceItems.Add(placeItem);
        }
    }
}
