using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.Places
{
    public class PlaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlaceType { get; set; }
        public int PlaceId { get; set; }

        public List<PlaceItemDto> PlaceItems { get; set; }
    }
}
