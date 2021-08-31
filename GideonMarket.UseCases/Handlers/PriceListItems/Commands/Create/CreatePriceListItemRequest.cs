using MediatR;
using System;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.PriceListItems.Commands
{
    public class CreatePriceListItemRequest : IRequest<int>
    {
        public int Id { get; set; }
        public int PriceId { get; set; }
        public int ProductId { get; set; }
        public decimal ManualPrice { get; set; }
    }
}
