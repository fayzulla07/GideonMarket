using MediatR;
using System;
using System.Collections.Generic;
using Mapster;

namespace GideonMarket.UseCases.Handlers.PriceLists.Commands
{
    public class UpdatePriceListRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PriceListItemDto> PriceItems { get; set; }
    }
}
