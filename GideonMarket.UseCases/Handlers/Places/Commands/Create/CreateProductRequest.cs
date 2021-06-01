using MediatR;

namespace GideonMarket.UseCases.Handlers.Places.Commands
{
    public class CreatePlaceRequest : IRequest<int>
    {
        public PlaceDto dto { get; set; }
    }
}
