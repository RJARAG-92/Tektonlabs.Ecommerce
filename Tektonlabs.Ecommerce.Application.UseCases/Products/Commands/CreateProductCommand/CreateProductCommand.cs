using MediatR;
using Tektonlabs.Ecommerce.Application.DTO;
using Tektonlabs.Ecommerce.Common;
using Tektonlabs.Ecommerce.Domain.Enums;

namespace Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand
{
    public sealed record CreateProductCommand : IRequest<Response<ProductInsertDto>>
    {
        public string Name { get; set; } = string.Empty;
        public ProductStatus Status { get; set; }
        public TipoUnidadMedida UnidadMedida { get; set; }
        public int Stock { get; set; }
        public TipoMoneda Moneda { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;


    }
}
