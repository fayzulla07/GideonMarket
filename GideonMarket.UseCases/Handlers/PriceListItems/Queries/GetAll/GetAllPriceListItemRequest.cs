using MediatR;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.PriceListItems.Queries
{
    public class GetAllPriceListItemRequest : IRequest<IEnumerable<PriceListItemDto>>
    {
    }
}
