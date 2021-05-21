using MediatR;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Commands
{
    public class DeleteProductTypeRequest : IRequest
    {
        public int Id { get; set; }
    }
}
