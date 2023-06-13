using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSharp.Models.QueryParameters
{
    public class StringParameterToken : ParameterToken
    {
        private string PropertyName { get; set; }
        private string Value { get; set; }

        private bool contains;

        /// <summary>
        /// Constructor of a string parameter token
        /// </summary>
        /// <param name="propertyName">The name of the property to use</param>
        /// <param name="value">The value to compare with</param>
        /// <param name="contains">Wether or not contains should be used. If contains is true it will check for properties containing the value, if it is false it will check for properties with the value of the value</param>
        public StringParameterToken(string propertyName, string value, bool contains)
        {
            PropertyName = propertyName;
            Value = value;
            this.contains = contains;
        }

        public override string ToString()
        {
            if (contains)
                return $"contains({PropertyName},'{Value}')";
            return $"{PropertyName} eq '{Value}'";
        }
    }
}
