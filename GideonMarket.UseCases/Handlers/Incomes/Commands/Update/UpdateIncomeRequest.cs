using MediatR;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    public class UpdateIncomeRequest : IRequest
    {
        public IncomeDto dto { get; set; }
    }
}
