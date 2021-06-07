using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    public class DeleteIncomeValidation : AbstractValidator<DeleteIncomeRequest>
    {
        public DeleteIncomeValidation()
        {
            RuleFor(s => s.Id)
                .NotNull();
        }

    }
}
