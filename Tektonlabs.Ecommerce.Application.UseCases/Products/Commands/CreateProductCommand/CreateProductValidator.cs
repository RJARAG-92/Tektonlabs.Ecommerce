using FluentValidation; 

namespace Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand
{
    public sealed class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            //RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
