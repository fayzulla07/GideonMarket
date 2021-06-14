using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Orders.Commands
{
    public class CreatOrderValidation : AbstractValidator<CreateOrderRequest>
    {
        public CreatOrderValidation()
        {
            RuleFor(s => s.Description)
                .NotEmpty()
                .MaximumLength(150);
        }
    }
}
