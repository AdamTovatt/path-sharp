using PathSharp.Models.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSharpTests
{
    [TestClass]
    public class ODataParameterTests
    {
        [TestMethod]
        public void Filter1()
        {
            ODataParameters parameters = new ODataParameters();

            parameters.AddFilterToken(new StringParameterToken("ReleaseName", "BotTest", false));

            Assert.AreEqual("$filter=ReleaseName%20eq%20%27BotTest%27", parameters.ToString());
        }

        [TestMethod]
        public void Filter2()
        {
            ODataParameters parameters = new ODataParameters();

            parameters.AddFilterToken(new LogicalOperatorParameterToken(PathSharp.Models.Enums.LogicalOperatorType.Not));
            parameters.AddFilterToken(new ParenthesisParameterToken(PathSharp.Models.Enums.ParenthesisType.Start));
            parameters.AddFilterToken(new IntegerParameterToken("SpecificPriorityValue", 46));
            parameters.AddFilterToken(new ParenthesisParameterToken(PathSharp.Models.Enums.ParenthesisType.End));
            parameters.AddFilterToken(new LogicalOperatorParameterToken(PathSharp.Models.Enums.LogicalOperatorType.And));
            parameters.AddFilterToken(new ParenthesisParameterToken(PathSharp.Models.Enums.ParenthesisType.Start));
            parameters.AddFilterToken(new StringParameterToken("ReleaseName", "Bot", true));
            parameters.AddFilterToken(new ParenthesisParameterToken(PathSharp.Models.Enums.ParenthesisType.End));
            parameters.Skip = 1;

            Assert.AreEqual("$filter=not%28SpecificPriorityValue%20eq%2046%29and%28contains%28ReleaseName%2C%27Bot%27%29%29&$skip=1", parameters.ToString());
        }
    }
}
