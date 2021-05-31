
using MediatR;

namespace GideonMarket.UseCases.Handlers.Customers.Queries
{
    public class GetCustomerRequest : IRequest<CustomerDto>
    {
        public int Id { get; set; }
    }
}
