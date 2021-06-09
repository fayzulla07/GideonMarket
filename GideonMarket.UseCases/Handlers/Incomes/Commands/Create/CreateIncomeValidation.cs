using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    public class CreatIncomeValidation : AbstractValidator<CreateIncomeRequest>
    {
        public CreatIncomeValidation()
        {
            RuleFor(s => s.Description)
                .NotEmpty()
                .MaximumLength(150);
        }
    }
}
