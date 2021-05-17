using FluentValidation;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Commands.Create
{
    public class DeleteProductTypeValidation : AbstractValidator<DeleteProductTypeRequest>
    {
        public DeleteProductTypeValidation()
        {
            RuleFor(s => s.Id)
                .NotNull();
        }

    }
}
