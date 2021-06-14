using GideonMarket.Entities.Exceptions;
using GideonMarket.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GideonMarket.Entities.Models
{
    public class Order : Entity, MainEntity
    {
        public string Description { get; private set; }
        public int Number { get; private set; }
        public DateTime RegDt { get; private set; }
        public int PlaceId { get; private set; }

        public List<OrderItem> OrderItems { get; private set; }

        public Order()
        {

        }
        public Order(string description, int number, DateTime regDt)
        {
            Description = description;
            Number = number;
            RegDt = regDt;
        }
        public void AddItem(OrderItem orderItem)
        {
            ValidateItem(orderItem);
            OrderItems.Add(orderItem);
        }

        public decimal GetTotalPrice()
        {
            return OrderItems.Sum(x => x.Total);
        }

        private void ValidateItem(OrderItem orderItem)
        {
            //if (orderItem == null)
            //    throw new OrderItemException($"{nameof(OrderItem)} не может быть Null");
            //if(orderItem.OrderId != Id)
            //    throw new OrderItemException($"не возможно добавить запись заказа который не принадлежит этому заказу");
        }
    }
}
