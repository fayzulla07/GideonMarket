using MediatR;
using System;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.PriceLists.Commands
{
    public class CreatePriceListRequest : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PriceListItemDto> PriceItems { get; set; }
    }
}
