using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Incomes.Commands
{
    public class UpdateIncomeValidation : AbstractValidator<UpdateIncomeRequest>
    {
        public UpdateIncomeValidation()
        {
            RuleFor(s => s.Description)
                .NotEmpty();
        }

    }
}
