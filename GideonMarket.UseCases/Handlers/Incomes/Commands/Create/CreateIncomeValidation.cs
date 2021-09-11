using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    public class CreatIncomeValidation : AbstractValidator<CreateIncomeRequest>
    {
        public CreatIncomeValidation()
        {
            RuleFor(s => s.Description)
                .MaximumLength(150);
            RuleFor(s => s.IncomeItems.Count)
              .GreaterThan(0);
        }
    }
}
