using System;
using System.Collections.Generic;

namespace GideonMarket.Web.Client.Pages.Income
{
    public class IncomeViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public int PlaceId { get; set; }
       
        public List<IncomeItemViewModel> IncomeItems { get; set; }
    }
}
