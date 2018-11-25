using System.Globalization;

namespace ProfitRobots.StrategyGenerator.PineScript
{
    static class ValuesFormatter
    {
        public static string FormatConst(this int val)
        {
            return val.ToString();
        }

        public static string FormatConst(this bool val)
        {
            return val ? "true" : "false";
        }

        public static string FormatConst(this double val)
        {
            return val.ToString("0.0#", CultureInfo.InvariantCulture);
        }

        public static string FormatConst(this string val)
        {
            return "\"" + val + "\"";
        }
    }
}
