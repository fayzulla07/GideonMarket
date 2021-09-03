using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Customers.Commands
{
    public class DeleteCustomerValidation : AbstractValidator<DeleteCustomerRequest>
    {
        public DeleteCustomerValidation()
        {
            RuleFor(s => s.Id)
                .NotNull();
        }

    }
}
