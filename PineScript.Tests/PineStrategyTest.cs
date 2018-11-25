using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ProfitRobots.StrategyGenerator.Model;
using ProfitRobots.StrategyGenerator.ModelParser;

namespace ProfitRobots.StrategyGenerator.PineScript.Tests
{
    [TestClass]
    public partial class PineStrategyTest
    {
        private static string GetTargetResult(string codeFile)
        {
            return System.IO.File.ReadAllText(System.IO.Path.Combine("../../../proper_results", codeFile));
        }

        private static string GetJson(string jsonName)
        {
            return System.IO.File.ReadAllText(System.IO.Path.Combine("../../../../../test_json", jsonName));
        }

        private static void DoIncludeTest(string testName)
        {
            DoIncludeTest(testName + ".json", testName + ".txt");
        }

        private static void DoIncludeTest(string jsonFile, string codeFile)
        {
            string json = GetJson(jsonFile);
            string targetResult = GetTargetResult(codeFile);
            var model = JsonConvert.DeserializeObject<StrategyModel>(json);
            var generator = new StrategyGenerator();
            var metaModel = MetaModelFactory.Create(model);
            var result = generator.Generate(metaModel);
            Assert.IsTrue(result.Contains(targetResult), string.Format("Target code not found: \n{0}\n in \n{1}", targetResult, result));
        }

        [TestMethod]
        public void Pine_Name()
        {
            DoIncludeTest("name");
        }
    }
}
