using FluentValidation;

namespace GideonMarket.UseCases.Handlers.PriceLists.Commands
{
    public class UpdatePriceListValidation : AbstractValidator<UpdatePriceListRequest>
    {
        public UpdatePriceListValidation()
        {
            RuleFor(s => s.Name)
                .NotEmpty();
        }

    }
}
