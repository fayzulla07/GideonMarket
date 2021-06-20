using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.PriceLists
{
   public class PriceListItemDto
    {
        public int Id { get; set; }
        public int PriceId { get; set; }
        public int ProductId { get; set; }
        public decimal ManualPrice { get; set; }
    }
}
