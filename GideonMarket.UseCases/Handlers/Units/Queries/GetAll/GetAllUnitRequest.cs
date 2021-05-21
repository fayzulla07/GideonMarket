using MediatR;
using System.Collections.Generic;


namespace GideonMarket.UseCases.Handlers.Units.Queries
{
    public class GetAllUnitRequest : IRequest<IEnumerable<UnitDto>>
    {
    }
}
