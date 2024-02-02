using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options; 

namespace Tektonlabs.Ecommerce.Infrastructure.MarketingApi.Options
{
    internal class MarketingServiceSetup : IConfigureOptions<MarketingServiceOptions>
    {
        private const string ConfigurationSectionName = "MarketingService";
        private readonly IConfiguration _configuration;

        public MarketingServiceSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(MarketingServiceOptions options)
        {
            _configuration.GetSection(ConfigurationSectionName).Bind(options);
        }
    }
}
