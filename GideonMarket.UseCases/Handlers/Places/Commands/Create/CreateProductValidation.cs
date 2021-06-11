using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Places.Commands
{
    public class CreatPlaceValidation : AbstractValidator<CreatePlaceRequest>
    {
        public CreatPlaceValidation()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .MaximumLength(150);
        }
    }
}
