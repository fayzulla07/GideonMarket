using FluentValidation;

namespace GideonMarket.UseCases.Handlers.PriceLists.Commands
{
    public class CreatPriceListValidation : AbstractValidator<CreatePriceListRequest>
    {
        public CreatPriceListValidation()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .MaximumLength(150);
        }
    }
}
