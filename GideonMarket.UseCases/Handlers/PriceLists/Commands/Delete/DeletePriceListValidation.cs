using FluentValidation;

namespace GideonMarket.UseCases.Handlers.PriceLists.Commands
{
    public class DeletePriceListValidation : AbstractValidator<DeletePriceListRequest>
    {
        public DeletePriceListValidation()
        {
            RuleFor(s => s.Id)
                .NotNull();
        }

    }
}
