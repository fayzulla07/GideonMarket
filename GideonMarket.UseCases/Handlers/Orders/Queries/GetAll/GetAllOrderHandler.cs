using GideonMarket.UseCases.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Orders.Queries
{
    internal class GetAllOrderHandler : IRequestHandler<GetAllOrderRequest, IEnumerable<OrderDto>>
    {
        private readonly IAppContext appContext;

        public GetAllOrderHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<IEnumerable<OrderDto>> Handle(GetAllOrderRequest request, CancellationToken cancellationToken)
        {
            //var places = await appContext.Places.Include(x => x.PlaceItems).ToListAsync();
            //var placeDtos = places.Adapt<PlaceDto[]>();
            return null;
        }
    

    }
}
