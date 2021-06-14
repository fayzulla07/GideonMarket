using MediatR;

namespace GideonMarket.UseCases.Handlers.Orders.Commands
{
    public class DeleteOrderRequest : IRequest
    {
        public int Id { get; set; }
    }
}
