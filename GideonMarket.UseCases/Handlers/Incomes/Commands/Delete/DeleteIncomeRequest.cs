using MediatR;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    public class DeleteIncomeRequest : IRequest
    {
        public int Id { get; set; }
    }
}
