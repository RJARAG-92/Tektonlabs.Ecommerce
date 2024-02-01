using MediatR;
using Tektonlabs.Ecommerce.Common;
using Tektonlabs.Ecommerce.Common.Enums;

namespace Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand
{
    public sealed record CreateProductCommand: IRequest<Response<bool>>
    {
        public string Name { get; set; } = string.Empty;
        public ProductStatus StatusId { get; set; }
        public TipoUnidadMedida UnidadMedida { get; set; }
        public int Stock { get; set; }
        public TipoMoneda Moneda { get; set; } 
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;


    }
}
