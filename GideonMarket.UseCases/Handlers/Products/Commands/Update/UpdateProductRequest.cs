using MediatR;

namespace GideonMarket.UseCases.Handlers.Products.Commands
{
    public class UpdateProductRequest : IRequest
    {
        
        public SetProductDto dto { get; set; }
    }
}
