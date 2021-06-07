using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    public class CreatIncomeValidation : AbstractValidator<CreateIncomeRequest>
    {
        public CreatIncomeValidation()
        {
            RuleFor(s => s.dto.Description)
                .NotEmpty()
                .MaximumLength(150);
        }
    }
}
