using PathSharp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSharp.Models.QueryParameters
{
    public class ParenthesisParameterToken : ParameterToken
    {
        public ParenthesisType ParenthesisType { get; set; }

        public ParenthesisParameterToken(ParenthesisType parenthesisType)
        {
            ParenthesisType = parenthesisType;
        }

        public override string ToString()
        {
            switch(ParenthesisType)
            {
                case ParenthesisType.Start:
                    return "(";
                    case ParenthesisType.End:
                    return ")";
                default:
                    throw new NotImplementedException("This type of parenthesis does not exist");
            }
        }
    }
}
