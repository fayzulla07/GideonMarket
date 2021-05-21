using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Units.Commands
{
    public class CreateUnitValidation : AbstractValidator<CreateUnitRequest>
    {
        public CreateUnitValidation()
        {
            RuleFor(s => s.dto.Name)
                .NotEmpty()
                .MaximumLength(150);
        }

    }
}
