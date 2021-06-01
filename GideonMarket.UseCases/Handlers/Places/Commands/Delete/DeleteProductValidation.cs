using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Places.Commands
{
    public class DeletePlaceValidation : AbstractValidator<DeletePlaceRequest>
    {
        public DeletePlaceValidation()
        {
            RuleFor(s => s.Id)
                .NotNull();
        }

    }
}
