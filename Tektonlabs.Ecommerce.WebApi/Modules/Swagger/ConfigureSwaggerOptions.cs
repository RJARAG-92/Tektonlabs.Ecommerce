using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Tektonlabs.Ecommerce.WebApi.Modules.Swagger
{
    /// Configure Swagger Options  
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = "Tekton Labs Technology Services API",
                Description = "ASP.NET Core 8 - Web API. ",
                TermsOfService = new Uri("https://tekton.com"),
                Contact = new OpenApiContact
                {
                    Name = "Ricardo Jara",
                    Email = "rjjarag@hotmail.com",
                    Url = new Uri("https://www.linkedin.com/in/ricardo-jara-gaspar-b7a515265/")
                },
                License = new OpenApiLicense
                {
                    Name = "Use under LICX",
                    Url = new Uri("https://tekton.com/licence")
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "Esta versión de la API ha quedado obsoleta.";
            }

            return info;
        }
    }
}
