using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Units.Commands.Create
{
    public class DeleteUnitValidation : AbstractValidator<DeleteUnitRequest>
    {
        public DeleteUnitValidation()
        {
            RuleFor(s => s.Id)
                .NotNull();
        }

    }
}
