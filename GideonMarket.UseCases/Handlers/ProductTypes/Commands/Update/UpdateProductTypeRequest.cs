
using MediatR;
namespace GideonMarket.UseCases.Handlers.ProductTypes.Commands
{
    public class UpdateProductTypeRequest : IRequest
    {
        
        public ProductTypeDto dto { get; set; }
    }
}
