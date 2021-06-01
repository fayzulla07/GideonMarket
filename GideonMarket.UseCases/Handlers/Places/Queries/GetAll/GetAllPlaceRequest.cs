using GideonMarket.UseCases.Handlers.Places;
using MediatR;
using System.Collections.Generic;

namespace GideonMarket.UseCases.Handlers.Places.Queries
{
    public class GetAllPlaceRequest : IRequest<IEnumerable<PlaceDto>>
    {
    }
}
