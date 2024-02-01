using Microsoft.Extensions.DependencyInjection;
using Tektonlabs.Ecommerce.Application.Interface.Persistence;
using Tektonlabs.Ecommerce.Persistence.Contexts;
using Tektonlabs.Ecommerce.Persistence.Repositories;

namespace Tektonlabs.Ecommerce.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>(); 
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
