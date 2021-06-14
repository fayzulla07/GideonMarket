using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Orders.Commands
{
    public class DeleteOrderValidation : AbstractValidator<DeleteOrderRequest>
    {
        public DeleteOrderValidation()
        {
            RuleFor(s => s.Id)
                .NotNull();
        }

    }
}
