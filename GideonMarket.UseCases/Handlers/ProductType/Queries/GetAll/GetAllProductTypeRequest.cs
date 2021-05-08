using GideonMarket.UseCases.Handlers.ProductType.Dto;
using MediatR;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.ProductType.Queries
{
    public class GetAllProductTypeRequest : IRequest<IEnumerable<ProductTypeDto>>
    {
    }
}
