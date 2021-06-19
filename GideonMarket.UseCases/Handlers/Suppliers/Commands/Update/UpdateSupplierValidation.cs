using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Suppliers.Commands
{
    public class UpdateSupplierValidation : AbstractValidator<UpdateSupplierRequest>
    {
        public UpdateSupplierValidation()
        {
            RuleFor(s => s.dto.FullName)
                .NotEmpty();
        }

    }
}
