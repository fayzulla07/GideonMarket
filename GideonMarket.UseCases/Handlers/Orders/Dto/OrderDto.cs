using System;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.Orders
{
   public class OrderDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public DateTime RegDt { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }
}
