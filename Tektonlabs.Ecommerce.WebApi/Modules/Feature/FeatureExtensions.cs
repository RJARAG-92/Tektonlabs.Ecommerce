using System.Text.Json.Serialization;

namespace Tektonlabs.Ecommerce.WebApi.Modules.Feature
{
    /// <summary>
    /// FeatureExtensions
    /// </summary>
    public static class FeatureExtensions
    {
        /// <summary>
        /// Implementación Feature
        /// </summary>
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "policyApiEcommerce";

            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"])
                                                                                        .AllowAnyHeader()
                                                                                        .AllowAnyMethod()
                                                                                        .AllowAnyOrigin()));
            services.AddMvc();
            services.AddControllers().AddJsonOptions(opts =>
            {
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);
            });

            return services;
        }
    }
}
