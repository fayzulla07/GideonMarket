using MediatR;

namespace GideonMarket.UseCases.Handlers.Places.Commands
{
    public class DeletePlaceRequest : IRequest
    {
        public int Id { get; set; }
    }
}
