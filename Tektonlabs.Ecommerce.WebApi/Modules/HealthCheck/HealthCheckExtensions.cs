namespace Tektonlabs.Ecommerce.WebApi.Modules.HealthCheck
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("EcommerceConnection"), tags: new[] { "database" });

            services.AddHealthChecksUI().AddSqlServerStorage(configuration.GetConnectionString("EcommerceConnection"));

            return services;
        }
    }
}
