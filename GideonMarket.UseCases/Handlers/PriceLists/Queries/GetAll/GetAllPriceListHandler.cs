using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.PriceLists.Queries
{
    internal class GetAllPriceListHandler : IRequestHandler<GetAllPriceListRequest, IEnumerable<PriceListDto>>
    {
        private readonly IAppContext appContext;

        public GetAllPriceListHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<IEnumerable<PriceListDto>> Handle(GetAllPriceListRequest request, CancellationToken cancellationToken)
        {
            var price = await appContext.PriceLists.Include(x => x.PriceItems).ToListAsync();
            var priceDtos = price.Adapt<PriceListDto[]>();
            return priceDtos;
        }
    

    }
}
