using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserRentalCar.Application.Behaviours
{
    public class UnHandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnHandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //analizara los metodos Handle del sistema
            try
            {
                //si todo esta bien Sigue
                return await next();
            }
            catch (Exception ex)
            {
                // si ocurre un error en la validacion
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "Aplication Request : Sucedio una excepcion para el request {Name} {@Request} ", requestName, request);
                throw;
            }
        }
    }
}
