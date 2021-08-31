using MediatR;
using System;
using System.Collections.Generic;
using Mapster;

namespace GideonMarket.UseCases.Handlers.PriceListItems.Commands
{
    public class UpdatePriceListItemRequest : IRequest
    {
        public int Id { get; set; }
        public int PriceId { get; set; }
        public int ProductId { get; set; }
        public decimal ManualPrice { get; set; }
    }
}
