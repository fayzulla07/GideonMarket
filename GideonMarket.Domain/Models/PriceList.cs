using GideonMarket.Entities.Shared;
using System.Collections.Generic;

namespace GideonMarket.Entities.Models
{
    public class PriceList : Entity, MainEntity
    {
        public string Name { get; private set; }
        public List<PriceListItem> PriceItems { get; private set; }
    }
}
