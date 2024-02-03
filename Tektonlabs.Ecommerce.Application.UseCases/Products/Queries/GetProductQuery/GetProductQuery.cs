using MediatR;
using Tektonlabs.Ecommerce.Application.DTO;
using Tektonlabs.Ecommerce.Common;

namespace Tektonlabs.Ecommerce.Application.UseCases.Products.Queries.GetProductQuery
{
    public sealed record class GetProductQuery : IRequest<Response<ProductDto>>
    {
        public int ProductId { get; }

        public GetProductQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
