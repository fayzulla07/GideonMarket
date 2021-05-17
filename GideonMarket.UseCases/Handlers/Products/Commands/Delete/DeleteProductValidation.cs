using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Products.Commands.Create
{
    public class DeleteProductValidation : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductValidation()
        {
            RuleFor(s => s.Id)
                .NotNull();
        }

    }
}
