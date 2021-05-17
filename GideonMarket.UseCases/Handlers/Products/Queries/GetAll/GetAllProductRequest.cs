using GideonMarket.UseCases.Handlers.Products.Dto;
using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.Products.Queries.GetAll
{
    public class GetAllProductRequest : IRequest<IEnumerable<GetProductDto>>
    {
    }
}
