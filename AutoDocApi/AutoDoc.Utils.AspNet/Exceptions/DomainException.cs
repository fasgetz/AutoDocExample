using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Utils.AspNet.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message = null) : base(message)
        {

        }
    }
}
