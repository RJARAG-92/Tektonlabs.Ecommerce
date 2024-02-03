using FluentValidation;

namespace Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand
{
    public sealed class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(4, 100);
            RuleFor(x => x.Status).IsInEnum();
            RuleFor(x => x.UnidadMedida).IsInEnum();
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0); ;
            RuleFor(x => x.Description).MaximumLength(300);
            RuleFor(x => x.Moneda).IsInEnum();
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}
