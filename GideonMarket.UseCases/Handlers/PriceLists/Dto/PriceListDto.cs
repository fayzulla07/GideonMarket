using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.PriceLists
{ 
    public class PriceListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PriceListItemDto> PriceItems { get; set; }
    }
}
