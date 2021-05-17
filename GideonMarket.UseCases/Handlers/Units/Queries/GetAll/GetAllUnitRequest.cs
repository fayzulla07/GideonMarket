using GideonMarket.UseCases.Handlers.Units.Dto;
using MediatR;
using System.Collections.Generic;


namespace GideonMarket.UseCases.Handlers.Units.Queries.GetAll
{
    public class GetAllUnitRequest : IRequest<IEnumerable<UnitDto>>
    {
    }
}
