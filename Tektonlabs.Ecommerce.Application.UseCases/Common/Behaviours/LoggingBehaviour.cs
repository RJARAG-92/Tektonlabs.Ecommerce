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
            _logger.LogInformation("Request Handling Start: {name} {@request}", typeof(TRequest).Name, JsonSerializer.Serialize(request));
            var response = await next();
            _logger.LogInformation("Response Handling Finish: {name} {@response}", typeof(TRequest).Name, JsonSerializer.Serialize(response));
            return response;
        }
    }
}
