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
    public class ResultResponseDto<TResult> : BaseResponseDto
            where TResult : class
    {
        [JsonConstructor]
        public ResultResponseDto(TResult result, ITraceHolder traceHolder) : base(traceHolder, ResponseStatus.Success)
        {
            Result = result;
        }

        public TResult Result { get; }
    }
}
