using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProfitRobots.StrategyGenerator.PineScript.Tests
{
    public partial class PineStrategyTest
    {
        [TestMethod]
        [TestCategory("Actions")]
        public void Pine_ActionBuy()
        {
            DoIncludeTest("action/buy");
        }

        [TestMethod]
        [TestCategory("Actions")]
        public void Pine_ActionSell()
        {
            DoIncludeTest("action/sell");
        }

        [TestMethod]
        [TestCategory("Actions")]
        public void Pine_ActionEntryBuy()
        {
            DoIncludeTest("action/entry_buy");
        }

        [TestMethod]
        [TestCategory("Actions")]
        public void Pine_ActionEntrySell()
        {
            DoIncludeTest("action/entry_sell");
        }

        //[TestMethod]
        //[TestCategory("Actions")]
        //public void Pine_ActionCustomizable()
        //{
        //    DoIncludeTest("action/customizable");
        //}

        [TestMethod]
        [TestCategory("Actions")]
        public void Pine_ActionExit()
        {
           DoIncludeTest("action/exit");
        }

        [TestMethod]
        [TestCategory("Actions")]
        public void Pine_ActionExitBuy()
        {
            DoIncludeTest("action/exit_buy");
        }

        [TestMethod]
        [TestCategory("Actions")]
        public void Pine_ActionExitSell()
        {
           DoIncludeTest("action/exit_sell");
        }
    }
}
