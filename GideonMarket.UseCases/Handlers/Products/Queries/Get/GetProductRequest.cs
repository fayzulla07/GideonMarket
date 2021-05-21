using MediatR;

namespace GideonMarket.UseCases.Handlers.Products.Queries
{
    public class GetProductRequest : IRequest<GetProductDto>
    {
        public int Id { get; set; }
    }
}
