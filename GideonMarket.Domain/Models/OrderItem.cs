using GideonMarket.Entities.Enums;
using GideonMarket.Entities.Shared;

namespace GideonMarket.Entities.Models
{
    public class OrderItem : Entity
    {
        public int OrderId { get; }
        public string Description { get;}
        public double Count { get; }
        public decimal Price { get; }
        public int ProductId { get; }
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
