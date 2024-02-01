using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tektonlabs.Ecommerce.Application.Interface.Persistence;
using Tektonlabs.Ecommerce.Persistencia.Contexts;
using Tektonlabs.Ecommerce.Persistencia.Repositories;

namespace Tektonlabs.Ecommerce.Persistencia
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>(); 
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
