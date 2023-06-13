using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSharp.Models.QueryParameters
{
    public class IntegerParameterToken : ParameterToken
    {
        public string PropertyName { get; set; }
        public int Value { get; set; }

        public IntegerParameterToken (string propertyName, int value)
        {
            PropertyName = propertyName;
            Value = value;
        }

        public override string ToString()
        {
            return $"{PropertyName} eq {Value}";
        }
    }
}
