using GideonMarket.Domain.Enums;
using GideonMarket.Domain.Exceptions;
using GideonMarket.Domain.Shared;
using System.Collections.Generic;

namespace GideonMarket.Domain.Models
{
    public class Place : Entity, MainEntity
    {
        public string Name { get;  }
        public PlaceType PlaceType { get; }
        public List<PlaceItem> PlaceItems { get; }


        public double Price { get;  }

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
