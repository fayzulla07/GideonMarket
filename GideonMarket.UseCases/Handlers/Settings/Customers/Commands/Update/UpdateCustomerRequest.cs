using MediatR;

namespace GideonMarket.UseCases.Handlers.Customers.Commands
{
    public class UpdateCustomerRequest : IRequest
    {
        
        public CustomerDto dto { get; set; }
    }
}
