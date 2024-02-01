using FluentValidation; 

namespace Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.UpdateProductCommand
{
    public sealed class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            //RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
