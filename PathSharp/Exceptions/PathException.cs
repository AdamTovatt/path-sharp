using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSharp.Exceptions
{
    public class PathException : Exception
    {
        public PathException(string message) : base(message) { }
    }
}
