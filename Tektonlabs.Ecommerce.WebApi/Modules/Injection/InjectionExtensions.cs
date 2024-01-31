using Tektonlabs.Ecommerce.WebApi.Modules.GlobalException;

namespace Tektonlabs.Ecommerce.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddTransient<GlobalExceptionHandler>();

            return services;
        }
    }
}
