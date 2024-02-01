using AutoMapper;
using MediatR; 
using Tektonlabs.Ecommerce.Application.DTO;
using Tektonlabs.Ecommerce.Application.Interface.Persistence;
using Tektonlabs.Ecommerce.Common;

namespace Tektonlabs.Ecommerce.Application.UseCases.Products.Queries.GetProductQuery
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, Response<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<ProductDto>();

            var product = await _unitOfWork.Products.GetAsync(request.ProductId);
            response.Data = _mapper.Map<ProductDto>(product);
            response.Message = "Elemento no encontrado!!!";
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }

            return response;
        }
    }
}
