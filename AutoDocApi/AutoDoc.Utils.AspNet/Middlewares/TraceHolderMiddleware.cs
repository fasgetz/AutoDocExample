using AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Utils.AspNet.Middlewares
{
    public class TraceHolderMiddleware
    {
        private readonly RequestDelegate _next;

        public TraceHolderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ITraceHolder traceHolder, IGuidGenerator guidGenerator)
        {
            traceHolder.TraceId = context.Request.Headers.FirstOrDefault(x => x.Key == "TraceId").Value.FirstOrDefault();
            traceHolder.TraceDepth = Convert.ToInt32(context.Request.Headers.FirstOrDefault(x => x.Key == "TraceDepth").Value.FirstOrDefault());
            if (traceHolder.TraceId == null)
            {
                //traceHolder.TraceId = Guid.NewGuid().ToString();
                traceHolder.TraceId = guidGenerator.GetGuid().ToString();
                context.Response.OnStarting(state =>
                {
                    var httpContext = (HttpContext)state;
                    httpContext.Response.Headers.Add("TraceId", traceHolder.TraceId);

                    return Task.CompletedTask;
                }, context);
            }
            if (traceHolder.TraceDepth < 1)
            {
                traceHolder.TraceDepth = 1;
                context.Response.OnStarting(state =>
                {
                    var httpContext = (HttpContext)state;
                    httpContext.Response.Headers.Add("TraceDepth", traceHolder.TraceDepth.ToString());

                    return Task.CompletedTask;
                }, context);
            }

            await _next(context);

        }
    }
}
