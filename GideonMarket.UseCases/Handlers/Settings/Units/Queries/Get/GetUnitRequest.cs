using MediatR;

namespace GideonMarket.UseCases.Handlers.Units.Queries
{
    public class GetUnitRequest : IRequest<UnitDto>
    {
        public int Id { get; set; }
    }
}
