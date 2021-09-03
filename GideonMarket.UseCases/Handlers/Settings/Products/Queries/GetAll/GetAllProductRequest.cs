using MediatR;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.Products.Queries
{
    public class GetAllProductRequest : IRequest<IEnumerable<ProductDto>>
    {
    }
}
