using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Suppliers.Commands
{
    public class DeleteSupplierValidation : AbstractValidator<DeleteSupplierRequest>
    {
        public DeleteSupplierValidation()
        {
            RuleFor(s => s.Id)
                .NotNull();
        }

    }
}
