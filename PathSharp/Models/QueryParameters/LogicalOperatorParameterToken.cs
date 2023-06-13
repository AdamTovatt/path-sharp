using PathSharp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSharp.Models.QueryParameters
{
    public class LogicalOperatorParameterToken : ParameterToken
    {
        public LogicalOperatorType OperatorType { get; set; }

        public LogicalOperatorParameterToken(LogicalOperatorType operatorType)
        {
            OperatorType = operatorType;
        }

        public override string ToString()
        {
            switch (OperatorType)
            {
                case LogicalOperatorType.And:
                    return "and";
                    case LogicalOperatorType.Or:
                    return "or";
                case LogicalOperatorType.Not:
                    return "not";
                default:
                    throw new NotImplementedException("This logical operator type is not implemented");
            }
        }
    }
}
