using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Customers.Commands
{
    public class UpdateCustomerValidation : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidation()
        {
            RuleFor(s => s.dto.FullName)
                .NotEmpty();
        }

    }
}
