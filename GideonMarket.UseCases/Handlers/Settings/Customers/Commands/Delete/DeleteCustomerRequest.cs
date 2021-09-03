using MediatR;

namespace GideonMarket.UseCases.Handlers.Customers.Commands
{
    public class DeleteCustomerRequest : IRequest
    {
        public int Id { get; set; }
    }
}
