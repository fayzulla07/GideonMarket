using GideonMarket.UseCases.Handlers.ProductTypes.Dto;
using MediatR;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Queries
{
    public class GetAllProductTypeRequest : IRequest<IEnumerable<ProductTypeDto>>
    {
    }
}
