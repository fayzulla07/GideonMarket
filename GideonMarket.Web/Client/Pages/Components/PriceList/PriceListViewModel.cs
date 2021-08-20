using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GideonMarket.Web.Client.Pages.Components.PriceList
{
    public class PriceListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PriceListItemViewModel> PriceItems { get; set; }
    }
}
