using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Products.Commands
{
    public class UpdateProductValidation : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidation()
        {
            RuleFor(s => s.dto.Name)
                .NotEmpty();
        }

    }
}
