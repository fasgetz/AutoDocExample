using AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutoDoc.Utils.TraceHolder.Models
{
    public class ErrorDto
    {
        private ErrorDto(ITraceHolder traceHolder)
        {
            TraceDepth = traceHolder?.TraceDepth ?? default;
            Time = DateTime.UtcNow;
        }

        [JsonConstructor]
        public ErrorDto(string code, string message, ITraceHolder traceHolder) : this(traceHolder)
        {
            Code = code;
            Message = message;
        }

        public ErrorDto(Exception e, ITraceHolder traceHolder) : this(traceHolder)
        {
            switch (e)
            {
                //case InternalServiceBadResponseException exception:
                //    Code = GetErrorCode(exception);
                //    Message = exception.Message;
                //    InnerErrors = exception.Errors;
                //    break;
                //case ValidationException exception:
                //    Code = GetErrorCode(exception);
                //    Message = exception.Message;
                //    break;
                //case DomainException exception:
                //    Code = GetErrorCode(exception);
                //    Message = exception.Message;
                //    break;
                default:
                    Code = GetErrorCode(e);
                    Message = e.Message;
                    break;
            }

            static string GetErrorCode(Exception e)
            {
                var exceptionTypeName = e.GetType().Name;
                var code = (exceptionTypeName.Length > 0 && exceptionTypeName[^9..].ToLowerInvariant() == nameof(Exception).ToLowerInvariant()) ?
                    exceptionTypeName[..^9] : exceptionTypeName;

                return code;
            }
        }

        public string Code { get; set; }

        public string Message { get; set; }

        public int TraceDepth { get; set; }

        public DateTime Time { get; set; }

        public ICollection<ErrorDto> InnerErrors { get; set; }
    }
}
