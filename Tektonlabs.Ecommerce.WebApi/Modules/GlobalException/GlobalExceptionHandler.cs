using System.Net;
using System.Text.Json;
using Tektonlabs.Ecommerce.Common;

namespace Tektonlabs.Ecommerce.WebApi.Modules.GlobalException
{
    /// <summary>
    /// Manejador Global de Exceptions
    /// </summary>
    public class GlobalExceptionHandler : IMiddleware
    {
        private ILogger<GlobalExceptionHandler> _logger;

        /// <summary>
        /// Constructor Manejador Global de Exceptions 
        /// </summary>
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Middleware para Manejador Global de Exceptions 
        /// </summary>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                _logger.LogError($"Exception Details: {message}");

                var response = new Response<Object>()
                {
                    Message = message
                };

                await JsonSerializer.SerializeAsync(context.Response.Body, response);
            }

        }
    }
}
