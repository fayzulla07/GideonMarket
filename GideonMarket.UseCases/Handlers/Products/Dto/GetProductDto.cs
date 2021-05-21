

namespace GideonMarket.UseCases.Handlers.Products
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProductTypeId { get; set; }
        public int UnitId { get; set; }
        public decimal Price { get; set; }
    }
}
