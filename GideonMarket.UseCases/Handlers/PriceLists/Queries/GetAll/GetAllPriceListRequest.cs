using MediatR;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.PriceLists.Queries
{
    public class GetAllPriceListRequest : IRequest<IEnumerable<PriceListDto>>
    {
    }
}
