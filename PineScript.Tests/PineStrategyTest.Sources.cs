using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProfitRobots.StrategyGenerator.PineScript.Tests
{
    public partial class PineStrategyTest
    {
        [TestMethod]
        public void Pine_IndicatorOnInstrument()
        {
            DoIncludeTest("sources/indicator_on_instrument");
        }

        [TestMethod]
        public void Pine_IndicatorOnMainSource()
        {
            DoIncludeTest("sources/indicator_on_main_source");
        }

        [TestMethod]
        public void Pine_MvaOnMainSourceClose()
        {
            DoIncludeTest("sources/mva_on_main_source_close");
        }

        [TestMethod]
        public void Pine_Rsi()
        {
            DoIncludeTest("sources/rsi");
        }

        [TestMethod]
        public void Pine_Macd()
        {
            DoIncludeTest("sources/macd");
        }

        [TestMethod]
        public void Pine_Stochastic()
        {
            DoIncludeTest("sources/Stochastic");
        }

        [TestMethod]
        public void Pine_MvaWithParameters()
        {
            DoIncludeTest("sources/mva_with_parameters");
        }

        [TestMethod]
        public void Pine_RsiWithParameters()
        {
            DoIncludeTest("sources/rsi_with_parameters");
        }

        [TestMethod]
        public void Pine_MacdWithParameters()
        {
            DoIncludeTest("sources/macd_with_parameters");
        }

        [TestMethod]
        public void Pine_StochWithParameters()
        {
            DoIncludeTest("sources/stochastic_with_parameters");
        }

        [TestMethod]
        public void Pine_IndicatorWithExternalParameters()
        {
           DoIncludeTest("sources/indicator_with_external_parameters");
        }

        [TestMethod]
        public void Pine_IndicatorBB()
        {
            DoIncludeTest("sources/bb");
        }

        [TestMethod]
        public void Pine_IndicatorBBWithParameters()
        {
            DoIncludeTest("sources/bb_with_parameters");
        }

        [TestMethod]
        public void Pine_IndicatorSAR()
        {
            DoIncludeTest("sources/sar");
        }

        [TestMethod]
        public void Pine_IndicatorSARWithParameters()
        {
            DoIncludeTest("sources/sar_with_parameters");
        }

        [TestMethod]
        public void Pine_IndicatorATR()
        {
            DoIncludeTest("sources/atr");
        }

        [TestMethod]
        public void Pine_IndicatorATRWithParameters()
        {
            DoIncludeTest("sources/atr_with_parameters");
        }

        [TestMethod]
        public void Pine_IndicatorCCI()
        {
            DoIncludeTest("sources/cci");
        }

        [TestMethod]
        public void Pine_IndicatorCCIWithParameters()
        {
            DoIncludeTest("sources/cci_with_parameters");
        }

        [TestMethod]
        public void Pine_IndicatorEMA()
        {
            DoIncludeTest("sources/ema");
        }

        [TestMethod]
        public void Pine_IndicatorEMAWithParameters()
        {
            DoIncludeTest("sources/ema_with_parameters");
        }

        [TestMethod]
        public void Pine_IndicatorSWMA()
        {
            DoIncludeTest("sources/swma");
        }

        [TestMethod]
        public void Pine_IndicatorTSI()
        {
            DoIncludeTest("sources/tsi");
        }

        [TestMethod]
        public void Pine_IndicatorTSIWithParameters()
        {
            DoIncludeTest("sources/tsi_with_parameters");
        }

        [TestMethod]
        public void Pine_IndicatorVWAP()
        {
            DoIncludeTest("sources/vwap");
        }

        [TestMethod]
        public void Pine_IndicatorVWMA()
        {
            DoIncludeTest("sources/vwma");
        }

        [TestMethod]
        public void Pine_IndicatorVWMAWithParameters()
        {
            DoIncludeTest("sources/vwma_with_parameters");
        }

        [TestMethod]
        public void Pine_IndicatorWMA()
        {
            DoIncludeTest("sources/wma");
        }

        [TestMethod]
        public void Pine_IndicatorWMAWithParameters()
        {
            DoIncludeTest("sources/wma_with_parameters");
        }
    }
}
