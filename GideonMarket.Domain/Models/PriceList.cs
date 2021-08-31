using GideonMarket.Entities.Shared;
using System.Collections.Generic;
using System.Linq;
namespace GideonMarket.Entities.Models
{
    public class PriceList : Entity, MainEntity
    {
        public string Name { get; set; }
        // auto include enabled    
        public List<PriceListItem> PriceItems { get; private set; }

        public void AddItem(List<PriceListItem> items)
        {
            if (PriceItems == null)
            {
                PriceItems = new List<PriceListItem>();
            }
            if (items == null) return;
            PriceItems.AddRange(items);
        }

        public void UpdateItem(List<PriceListItem> items)
        {
            foreach (var item in items)
            {
                Update(item);
            }
           
        }

      
        private void Update(PriceListItem entity)
        {
            foreach (var item in PriceItems)
            {
                if(item.Id == entity.Id)
                {
                    item.Update(entity.PriceId, entity.ProductId, entity.ManualPrice);
                }

            }

        }
    }
}
