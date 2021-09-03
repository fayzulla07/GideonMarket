using MediatR;


namespace GideonMarket.UseCases.Handlers.ProductTypes.Commands
{
    public class CreateProductTypeRequest : IRequest<int>
    {
        public ProductTypeDto dto { get; set; }
    }
}
