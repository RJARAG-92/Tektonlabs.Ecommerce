using Asp.Versioning.ApiExplorer;
using HealthChecks.UI.Client;
using Serilog;
using Tektonlabs.Ecommerce.Application.UseCases;
using Tektonlabs.Ecommerce.Infrastructure;
using Tektonlabs.Ecommerce.Persistencia;
using Tektonlabs.Ecommerce.WebApi.Modules.Feature;
using Tektonlabs.Ecommerce.WebApi.Modules.HealthCheck;
using Tektonlabs.Ecommerce.WebApi.Modules.Injection;
using Tektonlabs.Ecommerce.WebApi.Modules.Middleware;
using Tektonlabs.Ecommerce.WebApi.Modules.Swagger;
using Tektonlabs.Ecommerce.WebApi.Modules.Versioning;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddFeature(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddSwagger();
builder.Services.AddHealthCheck(builder.Configuration);

// Use Serilog for logging and read configuration from appsettings
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // build a swagger endpoint for each discovered API version

        foreach (var description in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();
app.UseCors("policyApiEcommerce");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.AddMiddleware();
// Allow httprequest logs in Serilog
app.UseSerilogRequestLogging();

app.Run();
