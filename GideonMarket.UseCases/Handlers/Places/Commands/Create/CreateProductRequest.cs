using MediatR;

namespace GideonMarket.UseCases.Handlers.Places.Commands
{
    public class CreatePlaceRequest : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlaceType { get; set; }
    }
}
