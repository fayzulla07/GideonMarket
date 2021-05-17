using FluentValidation;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Commands.Create
{
    public class UpdateProductTypeValidation : AbstractValidator<UpdateProductTypeRequest>
    {
        public UpdateProductTypeValidation()
        {
            RuleFor(s => s.dto.Name)
                .NotEmpty();

            RuleFor(s => s.dto.Id)
                .NotNull();
        }

    }
}
