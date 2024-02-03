using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tektonlabs.Ecommerce.Application.Interface.Infrastructure;
using Tektonlabs.Ecommerce.Infrastructure.MarketingApi;
using Tektonlabs.Ecommerce.Infrastructure.MarketingApi.Options;

namespace Tektonlabs.Ecommerce.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureOptions<MarketingServiceSetup>();
            services.AddScoped<IMarketingApi, MarketingService>();
            return services;
        }
    }
}
