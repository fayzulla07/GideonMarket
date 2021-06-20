using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Suppliers.Commands
{
    public class CreatSupplierValidation : AbstractValidator<CreateSupplierRequest>
    {
        public CreatSupplierValidation()
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
