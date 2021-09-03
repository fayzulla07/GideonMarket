using FluentValidation;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Commands
{
    public class CreateProductTypeValidation : AbstractValidator<CreateProductTypeRequest>
    {
        public CreateProductTypeValidation()
        {
            RuleFor(s => s.dto.Name)
                .NotEmpty().WithMessage("Напишите имя типа продукта!")
                .MaximumLength(150).WithMessage("Имя должен быть меньше чем 150 символ");
        }

    }
}
