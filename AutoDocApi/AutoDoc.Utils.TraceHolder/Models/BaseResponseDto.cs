using AutoDoc.Utils.TraceHolder.Enums;
using AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Utils.TraceHolder.Models
{
    public class BaseResponseDto
    {
        protected BaseResponseDto(ITraceHolder traceHolder, ResponseStatus status)
        {
            TraceId = traceHolder?.TraceId;
            Status = status;
        }

        public ResponseStatus Status { get; set; }

        public string TraceId { get; set; }
    }
}
