using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.PriceListItems.Queries
{
    internal class GetAllPriceListItemHandler : IRequestHandler<GetAllPriceListItemRequest, IEnumerable<PriceListItemDto>>
    {
        private readonly IAppContext appContext;

        public GetAllPriceListItemHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<IEnumerable<PriceListItemDto>> Handle(GetAllPriceListItemRequest request, CancellationToken cancellationToken)
        {
            var priceitems = await appContext.PriceListItems.ToListAsync();
            var priceitemsDtos = priceitems.Adapt<PriceListItemDto[]>();
            return priceitemsDtos;
        }
    

    }
}
