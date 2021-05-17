using GideonMarket.UseCases.Handlers.Products.Dto;
using MediatR;

namespace GideonMarket.UseCases.Handlers.Products.Queries.Get
{
    public class GetProductRequest : IRequest<GetProductDto>
    {
        public int Id { get; set; }
    }
}
