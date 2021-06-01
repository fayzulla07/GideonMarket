using MediatR;

namespace GideonMarket.UseCases.Handlers.Places.Commands
{
    public class UpdatePlaceRequest : IRequest
    {
        public PlaceDto dto { get; set; }
    }
}
