using AutoMapper;
using LazyCache;
using MediatR;
using Tektonlabs.Ecommerce.Application.DTO;
using Tektonlabs.Ecommerce.Application.Interface.Infrastructure;
using Tektonlabs.Ecommerce.Application.Interface.Persistence;
using Tektonlabs.Ecommerce.Common;
using Tektonlabs.Ecommerce.Domain.Common;

namespace Tektonlabs.Ecommerce.Application.UseCases.Products.Queries.GetProductQuery
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, Response<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMarketingApi _marketingApi;
        private readonly IAppCache _lazyCache;
        public GetProductHandler(IUnitOfWork unitOfWork, IMapper mapper, IMarketingApi marketingApi, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _marketingApi = marketingApi;
            _lazyCache = cache;
        }
        public async Task<Response<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<ProductDto>();

            var product = await _unitOfWork.Products.GetAsync(request.ProductId);
            response.Data = _mapper.Map<ProductDto>(product);
            response.Message = "Elemento no encontrado!!!";

            if (response.Data != null)
            {
                var _productsStates = await GetProductStatesAllAsync();
                var discount = await _marketingApi.GetDiscountAsync(request.ProductId);
                response.Data.StatusName = _productsStates[Convert.ToString(response.Data.StatusId)];
                response.Data.Discount = discount.PercentValue;
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }

            return response;
        }
        private async Task<Dictionary<string, string>?> GetProductStatesAllAsync()
        {
            string cacheKey = $"ProductsStates";
            return await _lazyCache.GetOrAddAsync(cacheKey, () => EnumExtensions.ProductStatusToList(), TimeSpan.FromMinutes(5));
        }

    }
}
