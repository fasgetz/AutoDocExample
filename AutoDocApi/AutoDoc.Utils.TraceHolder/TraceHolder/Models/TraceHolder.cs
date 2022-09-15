using AutoDoc.Utils.TraceHolder.Enums;
using AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Utils.TraceHolder.TraceHolder.Models
{
    public class TraceHolder : ITraceHolder
    {
        public string TraceId { get; set; }
        public int TraceDepth { get; set; }
    }
}
