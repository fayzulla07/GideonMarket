using GideonMarket.Entities.Enums;
using GideonMarket.Entities.Shared;

namespace GideonMarket.Entities.Models
{
    public class OrderItem : Entity
    {
        public int OrderId { get; private set; }
        public string Description { get; private set; }
        public double Count { get; private set; }
        public decimal Price { get; private set; }
        public int ProductId { get; private set; }
        public OrderItemStatus OrderItemStatus { get; private set; }
        public OrderItem(int orderId, string description, int productId, double count, decimal price, OrderItemStatus orderItemStatus)
        {
            OrderId = orderId;
            Description = description;
            ProductId = productId;
            Count = count;
            Price = price;
            OrderItemStatus = orderItemStatus;
        }
        public decimal Total
        {
            get { return Price * (decimal)Count; }
        }

    }
}
