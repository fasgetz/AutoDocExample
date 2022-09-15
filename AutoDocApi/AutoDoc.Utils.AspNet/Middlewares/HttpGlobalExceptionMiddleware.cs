using AutoDoc.Utils.AspNet.DataTypes;
using AutoDoc.Utils.TraceHolder.Models;
using AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Utils.AspNet.Middlewares
{
    /// <summary>
    /// Обработчик ошибок
    /// </summary>
    public class HttpGlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpGlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ITraceHolder traceHolder)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = 400;
                httpContext.Response.ContentType = ContentType.Json;

                var responseDto = ex switch
                {
                    _ => new ErrorResponseDto(ex, traceHolder)
                };
                var responseJson = JsonConvert.SerializeObject(responseDto);

                await httpContext.Response.WriteAsync(responseJson);
            }
        }
    }
}
