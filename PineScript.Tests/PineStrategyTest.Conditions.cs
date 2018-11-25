using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProfitRobots.StrategyGenerator.PineScript.Tests
{
    public partial class PineStrategyTest
    {
        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_IndicatorCrossesValue()
        {
            DoIncludeTest("condition/condition_crosses_value");
        }

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_IndicatorCrossesOverValue()
        {
            DoIncludeTest("condition/condition_crossesOver_value");
        }

        //[TestMethod]
        //[TestCategory("Conditions")]
        //public void Pine_IndicatorCrossesOverOrTouchValue()
        //{
        //    DoIncludeTest("condition/condition_crossesOverOrTouch_value.json", "condition/condition_crossesOverOrTouch_value.txt");
        //}

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_IndicatorCrossesUnderValue()
        {
            DoIncludeTest("condition/condition_crossesUnder_value");
        }

        //[TestMethod]
        //[TestCategory("Conditions")]
        //public void Pine_IndicatorCrossesUnderOrTouchValue()
        //{
        //    DoIncludeTest("condition/condition_crossesUnderOrTouch_value.json", "condition/condition_crossesUnderOrTouch_value.txt");
        //}

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_IndicatorCrossesInstrumentClose()
        {
            DoIncludeTest("condition/crosses_instrument_close");
        }

        //[TestMethod]
        //[TestCategory("Conditions")]
        //public void Pine_IndicatorCrossFixedPeriodsBack()
        //{
        //    DoIncludeTest("condition/cross_fixed_periods_back.json", "condition/cross_fixed_periods_back.txt");
        //}

        //[TestMethod]
        //[TestCategory("Conditions")]
        //public void Pine_IndicatorCrossDifferentTFShift()
        //{
        //    DoIncludeTest("condition/cross_different_tf_shift");
        //}

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_GTPrice()
        {
            DoIncludeTest("condition/gt_price");
        }

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_GTStreamValue()
        {
            DoIncludeTest("condition/gt_stream_value");
        }

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_GTStream()
        {
            DoIncludeTest("condition/gt_stream");
        }

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_LTStreamValue()
        {
            DoIncludeTest("condition/lt_stream_value");
        }

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_LTEStreamValue()
        {
            DoIncludeTest("condition/lte_stream_value");
        }

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_GTEStreamValue()
        {
            DoIncludeTest("condition/gte_stream_value");
        }

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_EQStreamValue()
        {
            DoIncludeTest("condition/eq_stream_value");
        }

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_NEQStreamValue()
        {
            DoIncludeTest("condition/neq_stream_value");
        }

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_And()
        {
            DoIncludeTest("condition/and");
        }

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_Or()
        {
            DoIncludeTest("condition/or");
        }

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_CrossStream()
        {
            DoIncludeTest("condition/cross_stream");
        }

        [TestMethod]
        [TestCategory("Conditions")]
        public void Pine_CrossParamValue()
        {
            DoIncludeTest("condition/condition_crosses_param_value");
        }
    }
}
