using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSharp.Models.QueryParameters
{
    /// <summary>
    /// Class that represents parameters that are often used of get methods
    /// </summary>
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

        /// <summary>
        /// Will add a filter token with a given key and value
        /// </summary>
        /// <param name="key">The key for the token</param>
        /// <param name="value">The value for the token</param>
        /// <param name="contains">Wether or not if the filter should check for things that contains the given string or if it needs to be exactly like the given string</param>
        public void AddFilterToken(string key, string value, bool contains = false)
        {
            filterTokens.Add(new StringParameterToken(key, value, contains));
        }

        /// <summary>
        /// Add a filter token. The parameter token can be of type StringParameterToken or IntegerParameterToken
        /// </summary>
        /// <param name="token"></param>
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
