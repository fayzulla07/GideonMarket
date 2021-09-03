using MediatR;

namespace GideonMarket.UseCases.Handlers.Products.Commands
{
    public class DeleteProductRequest : IRequest
    {
        public int Id { get; set; }
    }
}
