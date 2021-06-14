using MediatR;
using System;
using System.Collections.Generic;
using Mapster;

namespace GideonMarket.UseCases.Handlers.Orders.Commands
{
    public class UpdateOrderRequest : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }        
        public List<OrderItemDto> OrderItems { get; set; }
        public int PlaceId { get; set; }
    }
}
