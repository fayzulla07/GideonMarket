using GideonMarket.Entities.Enums;

namespace GideonMarket.UseCases.Handlers.Orders
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        //public int OrderId { get; set; }
        public string Description { get; set; }
        public double Count { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public OrderItemStatus OrderItemStatus { get; set; }
    }
}
