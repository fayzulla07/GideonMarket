using GideonMarket.UseCases.Handlers.Units.Dto;
using MediatR;

namespace GideonMarket.UseCases.Handlers.Units.Commands
{
    public class CreateUnitRequest : IRequest<int>
    {
        public UnitDto dto { get; set; }
    }
}
