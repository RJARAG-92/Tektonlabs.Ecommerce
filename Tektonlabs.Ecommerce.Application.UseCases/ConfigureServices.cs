using LazyCache;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tektonlabs.Ecommerce.Application.UseCases.Common.Behaviours;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.UpdateProductCommand;

namespace Tektonlabs.Ecommerce.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<CreateProductValidator>();
            services.AddTransient<UpdateProductValidator>();
            services.AddSingleton<IAppCache, CachingService>();

            return services;
        }
    }
}
