using MediatR;
using Microsoft.Extensions.Logging;
using RPS.Application.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace RPS.Application.Behaviors
{
    public class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<ExceptionBehavior<TRequest, TResponse>> _logger;

        public ExceptionBehavior(ILogger<ExceptionBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
  
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                var response = await next().ConfigureAwait(false);
                return response;
            }
            catch (ValidationException ve)
            {
                _logger.LogError(ve, "Validation exception");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Application layer exeption full data");
                throw new ClientExceptions(ex.Message);
            }

            return default;
        }
    }
}
