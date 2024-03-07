using Azure.Core;
using BrowserRentalCar.Application.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace BrowserRentalCar.Api.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;//pipe line que continuara si no existe excepcion
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;// para validar en que ambiente estoy

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Capturar y manejar la excepción
                _logger.LogError(ex, ex.Message);

                // Configurar la respuesta HTTP con el tipo de contenido y el código de estado adecuados
                context.Response.ContentType = ContentType.ApplicationJson.ToString();
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;

                //personalizar Excepcion
                switch (ex)
                {
                    case NotFoundException notFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, validationJson));
                        break;

                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    default:
                        break;
                }

                // si el result esta en blanco, instanciara nuevamente al objeto codeErrorException
                if (string.IsNullOrEmpty(result))
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, ex.StackTrace));

                context.Response.StatusCode = statusCode;

                //envia el mensaje Json hacia el cliente
                await context.Response.WriteAsync(result);
            }
        }
    }
}