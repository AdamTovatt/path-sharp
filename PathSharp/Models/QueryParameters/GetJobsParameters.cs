using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSharp.Models.QueryParameters
{
    public class GetJobsParameters : QueryParameterCollection
    {
        public string? Expand { get; set; }
        public string? Filter { get; set; }
        public string? OrderBy { get; set; }
        public int? Top { get; set; }
        public int? Skip { get; set; }
        public bool? Count { get; set; }

        public GetJobsParameters() : base(true, true) { }
    }
}
