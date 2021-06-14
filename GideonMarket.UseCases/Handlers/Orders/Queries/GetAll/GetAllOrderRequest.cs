using MediatR;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.Orders.Queries
{
    public class GetAllOrderRequest : IRequest<IEnumerable<OrderDto>>
    {
    }
}
