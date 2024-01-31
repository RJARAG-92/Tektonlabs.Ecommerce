using Tektonlabs.Ecommerce.WebApi.Modules.GlobalException;

namespace Tektonlabs.Ecommerce.WebApi.Modules.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
