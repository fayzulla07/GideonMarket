using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.Places
{
    public class PlaceDto
    {
        public string Name { get; set; }
        public int PlaceType { get; set; }
        public List<PlaceItemDto> PlaceItems { get; set; }
    }
}
