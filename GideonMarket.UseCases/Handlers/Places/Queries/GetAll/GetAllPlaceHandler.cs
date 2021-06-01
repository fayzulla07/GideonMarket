using GideonMarket.UseCases.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Places.Queries
{
    internal class GetAllPlaceHandler : IRequestHandler<GetAllPlaceRequest, IEnumerable<PlaceDto>>
    {
        private readonly IAppContext appContext;

        public GetAllPlaceHandler(IAppContext appContext)   
        {
            this.appContext = appContext;
        }
        public async Task<IEnumerable<PlaceDto>> Handle(GetAllPlaceRequest request, CancellationToken cancellationToken)
        {
            var places = await appContext.Places.Include(x => x.PlaceItems).ToListAsync();
            var placeDtos = places.Adapt<PlaceDto[]>();
            return placeDtos;
        }
    }
}
