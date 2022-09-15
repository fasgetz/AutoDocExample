using AutoDoc.Utils.AspNet.ActionResults;
using AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Utils.AspNet.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private readonly ITraceHolder _traceHolder;

        protected BaseApiController(ITraceHolder traceHolder)
        {
            _traceHolder = traceHolder;
        }

        public IActionResult OkApi<TResult>(TResult result)
            where TResult : class
        {
            return new OkApiActionResult<TResult>(result, _traceHolder);
        }
    }
}
