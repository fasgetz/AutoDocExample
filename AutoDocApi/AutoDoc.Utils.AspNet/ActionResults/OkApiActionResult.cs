using AutoDoc.Utils.TraceHolder.Models;
using AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Utils.AspNet.ActionResults
{
    public class OkApiActionResult<TResult> : OkObjectResult
        where TResult : class
    {
        public OkApiActionResult(TResult result, ITraceHolder traceHolder) : base(new ResultResponseDto<TResult>(result, traceHolder)) { }
    }
}
