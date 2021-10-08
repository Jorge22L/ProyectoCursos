﻿using Aplicacion.ManejadorError;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebAPI.Middleware
{
    public class ManejadorErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ManejadorErrorMiddleware> _logger;
        public ManejadorErrorMiddleware(RequestDelegate next, ILogger<ManejadorErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await ManejadorExceptionAsincrono(context, e, _logger);
            }
            
        }

        private async Task ManejadorExceptionAsincrono(HttpContext context, Exception e, ILogger<ManejadorErrorMiddleware> logger)
        {
            object errores = null;
            switch (e)
            {
                case ManejadorExcepcion me:
                    logger.LogError(e, "Manejador Error");
                    errores = me.Errores;
                    context.Response.StatusCode = (int)me.Codigo;
                    break;
                case Exception ex:
                    logger.LogError(ex, "Error de Servidor");
                    errores = string.IsNullOrWhiteSpace(ex.Message) ? "Error" : ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            if(errores != null)
            {
                var resultados = JsonConvert.SerializeObject(new { errores });
                await context.Response.WriteAsync(resultados);
            }
        }
    }
}
