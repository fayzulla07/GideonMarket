using GideonMarket.UseCases.Handlers.Units.Dto;
using MediatR;

namespace GideonMarket.UseCases.Handlers.Units.Queries.Get
{
    public class GetUnitRequest : IRequest<UnitDto>
    {
        public int Id { get; set; }
    }
}
