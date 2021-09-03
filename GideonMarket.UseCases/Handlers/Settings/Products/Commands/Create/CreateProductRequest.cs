using MediatR;

namespace GideonMarket.UseCases.Handlers.Products.Commands
{
    public class CreateProductRequest : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProductTypeId { get; set; }
        public int UnitId { get; set; }
        public bool IsMaterial { get; set; }
    }
}
