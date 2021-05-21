using MediatR;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Queries
{
    public class GetProductTypeRequest : IRequest<ProductTypeDto>
    {
        public int Id { get; set; }
    }
}
