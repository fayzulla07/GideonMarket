using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Customers.Commands
{
    public class CreatCustomerValidation : AbstractValidator<CreateCustomerRequest>
    {
        public CreatCustomerValidation()
        {
            RuleFor(s => s.dto.FullName)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(s => s.dto.Email)
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}
