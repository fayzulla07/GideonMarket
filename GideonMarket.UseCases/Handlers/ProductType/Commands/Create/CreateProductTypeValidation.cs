using FluentValidation;

namespace GideonMarket.UseCases.Handlers.ProductType.Commands.Create
{
    public class CreateProductTypeValidation : AbstractValidator<CreateProductTypeRequest>
    {
        public CreateProductTypeValidation()
        {
            RuleFor(s => s.dto.Name)
                .NotEmpty()
                .MaximumLength(150);
        }

    }
}
