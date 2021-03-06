using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Units.Commands
{
    public class UpdateUnitValidation : AbstractValidator<UpdateUnitRequest>
    {
        public UpdateUnitValidation()
        {
            RuleFor(s => s.dto.Name)
                .NotEmpty();

            RuleFor(s => s.dto.Id)
                .NotNull();
        }

    }
}
