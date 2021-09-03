using MediatR;

namespace GideonMarket.UseCases.Handlers.Products.Queries
{
    public class GetProductRequest : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public bool IsMaterial { get; set; } = false;
    }
}
