using System;
using System.Collections.Generic;

namespace GideonMarket.Web.Client.Pages.Components.Place
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlaceType { get; set; }
        public List<PlaceItemViewModel> PlaceItems { get; set; }
    }
}
