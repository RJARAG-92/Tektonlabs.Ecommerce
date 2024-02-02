using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tektonlabs.Ecommerce.Common;
using Tektonlabs.Ecommerce.Common.Enums;

namespace Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.UpdateProductCommand
{
    public sealed record class UpdateProductCommand : IRequest<Response<bool>>
    {
        public int ProductId { get; set; } 
        public string Name { get; set; } = string.Empty;
        public ProductStatus Status { get; set; }
        public TipoUnidadMedida UnidadMedida { get; set; }
        public int Stock { get; set; }
        public TipoMoneda Moneda { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

    }
}
