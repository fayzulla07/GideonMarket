using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GideonMarket.Web.Client.Pages.Components.PriceList
{
    public class PriceListItemViewModel
    {
        public int Id { get; set; }
        public int PriceId { get; set; }
        public int ProductId { get; set; }
        public decimal ManualPrice { get; set; }
    }
}
