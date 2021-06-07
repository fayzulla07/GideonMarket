using MediatR;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    public class CreateIncomeRequest : IRequest<int>
    {
        public IncomeDto dto { get; set; }
        public int PlaceId{ get; set; }
    }
}
