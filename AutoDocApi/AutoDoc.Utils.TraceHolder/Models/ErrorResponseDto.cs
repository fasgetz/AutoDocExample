using AutoDoc.Utils.TraceHolder.Enums;
using AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutoDoc.Utils.TraceHolder.Models
{
    public class ErrorResponseDto : BaseResponseDto
    {
        [JsonConstructor]
        public ErrorResponseDto(string code, string message, ITraceHolder traceHolder) : base(traceHolder, ResponseStatus.Error)
        {
            Errors = new List<ErrorDto>()
            {
                new ErrorDto(code, message, traceHolder)
            };
        }

        public ErrorResponseDto(Exception e, ITraceHolder traceHolder) : base(traceHolder, ResponseStatus.Error)
        {
            Errors = e switch
            {
                AggregateException aggregateException => aggregateException.InnerExceptions.Select(inEx => new ErrorDto(inEx, traceHolder)).ToList(),
                _ => new List<ErrorDto>() { new ErrorDto(e, traceHolder) },
            };
        }

        public ICollection<ErrorDto> Errors { get; set; }
    }
}
