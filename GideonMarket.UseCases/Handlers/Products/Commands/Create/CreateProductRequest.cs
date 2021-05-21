using MediatR;

namespace GideonMarket.UseCases.Handlers.Products.Commands
{
    public class CreateProductRequest : IRequest<int>
    {
        public SetProductDto dto { get; set; }
    }
}
