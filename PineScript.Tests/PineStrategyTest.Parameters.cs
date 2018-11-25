using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProfitRobots.StrategyGenerator.PineScript.Tests
{
    public partial class PineStrategyTest
    {
        [TestMethod]
        [TestCategory("Parameters")]
        public void Pine_IntValueFromParameter()
        {
            DoIncludeTest("parameters/int_value_from_parameter");
        }

        //[TestMethod]
        //[TestCategory("Parameters")]
        //public void Pine_TimeframeParameter()
        //{
        //    DoIncludeTest("parameters/timeframe_value_from_parameter");
        //}

        //[TestMethod]
        //[TestCategory("Parameters")]
        //public void Pine_PriceTypeParameter()
        //{
        //    DoIncludeTest("parameters/priceType_value_from_parameter");
        //}

        [TestMethod]
        [TestCategory("Parameters")]
        public void Pine_IntParameter()
        {
            DoIncludeTest("parameters/int_parameter");
        }

        //[TestMethod]
        //[TestCategory("Parameters")]
        //public void Pine_StringParameter()
        //{
        //    DoIncludeTest("parameters/string_parameter");
        //}

        [TestMethod]
        [TestCategory("Parameters")]
        public void Pine_BoolParameter()
        {
            DoIncludeTest("parameters/bool_parameter");
        }

        [TestMethod]
        [TestCategory("Parameters")]
        public void Pine_BoolValueFromParameter()
        {
            DoIncludeTest("parameters/bool_value_from_parameter");
        }

        [TestMethod]
        [TestCategory("Parameters")]
        public void Pine_PriceParameter()
        {
           DoIncludeTest("parameters/price_parameter");
        }

        [TestMethod]
        [TestCategory("Parameters")]
        public void Pine_DoubleParameter()
        {
            DoIncludeTest("parameters/double_parameter");
        }

        [TestMethod]
        [TestCategory("Parameters")]
        public void Pine_DoubleValueFromParameter()
        {
            DoIncludeTest("parameters/double_value_from_parameter");
        }
    }
}
