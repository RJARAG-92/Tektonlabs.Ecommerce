using Asp.Versioning.ApiExplorer;
using Tektonlabs.Ecommerce.Application.UseCases;
using Tektonlabs.Ecommerce.WebApi.Modules.Feature;
using Tektonlabs.Ecommerce.WebApi.Modules.Injection;
using Tektonlabs.Ecommerce.WebApi.Modules.Middleware;
using Tektonlabs.Ecommerce.WebApi.Modules.Swagger;
using Tektonlabs.Ecommerce.WebApi.Modules.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddFeature(builder.Configuration);
//builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddSwagger();

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

    //app.UseReDoc(options =>
    //{
    //    foreach (var description in provider.ApiVersionDescriptions)
    //    {
    //        options.DocumentTitle = "Pacagroup Technology Services API Market";
    //        options.SpecUrl = $"/swagger/{description.GroupName}/swagger.json";
    //    }
    //});
}

app.UseHttpsRedirection();
app.UseCors("policyApiEcommerce");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.AddMiddleware();

app.Run();