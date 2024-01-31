using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tektonlabs.Ecommerce.Application.DTO;

namespace Tektonlabs.Ecommerce.Application.Validator
{
    public class ProductsDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductsDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            //RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
