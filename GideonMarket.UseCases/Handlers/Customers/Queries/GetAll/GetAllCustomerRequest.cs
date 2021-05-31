using MediatR;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.Customers.Queries
{
    public class GetAllCustomerRequest : IRequest<IEnumerable<CustomerDto>>
    {
    }
}
