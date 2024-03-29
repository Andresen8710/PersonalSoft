﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserRentalCar.Application.Exceptions
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public CodeErrorResponse(int statusCode, string? message=null)
        {
            StatusCode = statusCode;
            Message = message?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El Request enviado tiene errores.",
                401 => "No tienes Autorizacion para este recurso.",
                404 => "No se encontro el recurso Solicitado.",
                500 => "Se producieron errores en el servidor.",
                _ => string.Empty
            };
        }
    }
}
