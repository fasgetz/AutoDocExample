using AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces;
using AutoDoc.Utils.TraceHolder.TraceHolder.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Utils.AspNet.Extensions
{
    public static class TraceHolderExtensions
    {
        public static IServiceCollection AddTraceHolder(this IServiceCollection services)
        {
            services.AddScoped<ITraceHolder, AutoDoc.Utils.TraceHolder.TraceHolder.Models.TraceHolder>();

            return services;
        }

        public static IServiceCollection AddGuidGenerator(this IServiceCollection services)
        {
            services.AddScoped<IGuidGenerator, GuidGenerator>();

            return services;
        }
    }
}
