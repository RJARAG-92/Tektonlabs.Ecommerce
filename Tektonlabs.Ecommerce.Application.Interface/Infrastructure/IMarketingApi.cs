using Tektonlabs.Ecommerce.Domain.MarketingApi;

namespace Tektonlabs.Ecommerce.Application.Interface.Infrastructure
{
    public interface IMarketingApi
    {
        public Task<DiscountModel> GetDiscountAsync(int id);

    }
}
