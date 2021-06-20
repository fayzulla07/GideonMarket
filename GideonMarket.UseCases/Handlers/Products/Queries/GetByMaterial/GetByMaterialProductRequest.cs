using MediatR;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.Products.Queries
{
    public class GetByMaterialProductRequest : IRequest<IEnumerable<GetProductDto>>
    {
        public bool IsMaterial { get; set; } = false;
    }
}
