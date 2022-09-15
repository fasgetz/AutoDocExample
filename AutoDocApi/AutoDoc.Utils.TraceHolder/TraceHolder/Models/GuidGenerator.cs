using AutoDoc.Utils.TraceHolder.TraceHolder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Utils.TraceHolder.TraceHolder.Models
{
    public class GuidGenerator : IGuidGenerator
    {
        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }
}
