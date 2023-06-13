using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSharp.Models.QueryParameters
{
    public class ODataParameters : QueryParameterCollection
    {
        public string? Expand { get; set; }
        public string? Filter { get { return GetFilterString(); } }
        public string? OrderBy { get; set; }
        public int? Top { get; set; }
        public int? Skip { get; set; }
        public bool? Count { get; set; }
        public string? Select { get; set; }

        private List<ParameterToken> filterTokens = new List<ParameterToken>();

        public ODataParameters() : base(true, true) { }

        public void AddFilterToken(ParameterToken token)
        {
            filterTokens.Add(token);
        }

        private string GetFilterString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach(ParameterToken token in filterTokens)
            {
                stringBuilder.Append(token.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
