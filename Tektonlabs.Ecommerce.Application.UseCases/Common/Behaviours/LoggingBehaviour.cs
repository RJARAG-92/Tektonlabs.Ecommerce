using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Tektonlabs.Ecommerce.Application.UseCases.Common.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Request Handling Start: {name} {@request}. {@Date}", typeof(TRequest).Name, JsonSerializer.Serialize(request), DateTime.UtcNow);

            var response = await next();

            _logger.LogInformation("Response Handling Finish: {name} {@response}. {@Date}", typeof(TRequest).Name, JsonSerializer.Serialize(response), DateTime.UtcNow);

            return response;
        }
    }
}
