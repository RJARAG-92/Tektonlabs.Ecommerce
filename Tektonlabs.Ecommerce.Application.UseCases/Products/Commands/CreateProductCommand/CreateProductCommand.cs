using MediatR;
using Tektonlabs.Ecommerce.Common;

namespace Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand
{
    public sealed record CreateProductCommand: IRequest<Response<bool>>
    {
        public string Name { get; set; } = string.Empty;
        public int StatusId { get; set; } = 0;
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

    }
}
