using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSharp.Exceptions
{
    public class AuthorizeException : PathApiException
    {
        public AuthorizeException(string message) : base(message) { }
    }
}
