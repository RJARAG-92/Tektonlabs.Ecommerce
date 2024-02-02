using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options; 
using System.Text.Json; 
using Tektonlabs.Ecommerce.Application.Interface.Infrastructure;
using Tektonlabs.Ecommerce.Domain.MarketingApi;
using Tektonlabs.Ecommerce.Infrastructure.MarketingApi.Options;

namespace Tektonlabs.Ecommerce.Infrastructure.MarketingApi
{
    public class MarketingService(IOptions<MarketingServiceOptions> options, ILogger<MarketingService> logger) : IMarketingApi
    {
        private readonly ILogger<MarketingService> _logger= logger;
        private readonly HttpClient _client = new HttpClient();
        private readonly MarketingServiceOptions _options = options.Value;
         
        public async Task<DiscountModel> GetDiscountAsync(int id)
        {
            DiscountModel discountModels = new DiscountModel(); ;
            Uri uri = new Uri(string.Format(Path.Combine( _options.UrlBase,_options.EndPointDiscounts,id.ToString()), string.Empty));
            HttpResponseMessage response = await _client.GetAsync(uri);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    discountModels = JsonSerializer.Deserialize<DiscountModel>(content);
                    return discountModels;
                }
                _logger.LogError($"MarketingService failed to {_options.EndPointDiscounts} with error code {response.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"MarketingService failed to {_options.EndPointDiscounts} with error code {response.StatusCode}");
            }
            return discountModels;
        }
    }
}
