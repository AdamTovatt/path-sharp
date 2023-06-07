using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSharp.Models.QueryParameters
{
    public class GetJobParameters : QueryParameterCollection
    {
        public string? Expand { get; set; }
        public string? Select { get; set; }
    }
}
