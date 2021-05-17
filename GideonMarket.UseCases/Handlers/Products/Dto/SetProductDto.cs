

namespace GideonMarket.UseCases.Handlers.Products.Dto
{
    public class SetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProductTypeId { get; set; }
        public int UnitId { get; set; }
    }
}
