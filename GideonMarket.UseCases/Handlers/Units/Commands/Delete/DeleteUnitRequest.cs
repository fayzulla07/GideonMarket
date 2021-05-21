using MediatR;

namespace GideonMarket.UseCases.Handlers.Units.Commands
{
    public class DeleteUnitRequest : IRequest
    {
        public int Id { get; set; }
    }
}
