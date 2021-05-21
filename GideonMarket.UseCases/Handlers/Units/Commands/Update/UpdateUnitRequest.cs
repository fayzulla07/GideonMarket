using MediatR;

namespace GideonMarket.UseCases.Handlers.Units.Commands
{
    public class UpdateUnitRequest : IRequest
    {
        public UnitDto dto { get; set; }
    }
}
