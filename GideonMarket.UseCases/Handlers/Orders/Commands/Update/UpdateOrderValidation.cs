using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Orders.Commands
{
    public class UpdateOrderValidation : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderValidation()
        {
            RuleFor(s => s.Description)
                .NotEmpty();
        }

    }
}
