using FluentValidation;

namespace GideonMarket.UseCases.Handlers.PriceListItems.Commands
{
    public class DeletePriceListItemValidation : AbstractValidator<DeletePriceListItemRequest>
    {
        public DeletePriceListItemValidation()
        {
            RuleFor(s => s.Id)
                .NotNull();
        }

    }
}
