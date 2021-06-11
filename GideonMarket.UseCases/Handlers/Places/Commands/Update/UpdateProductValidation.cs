using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Places.Commands
{
    public class UpdatePlaceValidation : AbstractValidator<UpdatePlaceRequest>
    {
        public UpdatePlaceValidation()
        {
            RuleFor(s => s.Name)
                .NotEmpty();
        }

    }
}
