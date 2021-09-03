using MediatR;

namespace GideonMarket.UseCases.Handlers.Customers.Commands
{
    public class CreateCustomerRequest : IRequest<int>
    {
        public CustomerDto dto { get; set; }
    }
}
