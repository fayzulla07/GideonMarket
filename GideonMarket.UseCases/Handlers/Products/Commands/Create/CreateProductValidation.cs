using FluentValidation;

namespace GideonMarket.UseCases.Handlers.Products.Commands
{
    public class CreatProductValidation : AbstractValidator<CreateProductRequest>
    {
        public CreatProductValidation()
        {
            RuleFor(s => s.dto.Name)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(s => s.dto.Description)
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}
