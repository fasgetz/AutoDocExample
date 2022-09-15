using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces
{
    public interface ITraceHolder
    {
        public string TraceId { get; set; }
        public int TraceDepth { get; set; }
    }
}
