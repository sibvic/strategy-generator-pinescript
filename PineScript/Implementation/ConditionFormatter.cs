using ProfitRobots.StrategyGenerator.Model;
using System.Linq;

namespace ProfitRobots.StrategyGenerator.PineScript
{
    class ConditionFormatter
    {
        /// <summary>
        /// Formats condition
        /// </summary>
        /// <param name="condition">Condition to format</param>
        /// <returns>Formatted code of the condition</returns>
        public static string FormatCondition(ICondition condition)
        {
            var twoArgumentCondition = condition as TwoArgumentCondition;
            switch (condition.ConditionType)
            {
                case ConditionType.Crosses:
                    return FormatCrossMethodCall(twoArgumentCondition.Arg1, twoArgumentCondition.Arg2, "cross");
                case ConditionType.CrossesOver:
                    return FormatCrossMethodCall(twoArgumentCondition.Arg1, twoArgumentCondition.Arg2, "crossover");
                //case ConditionType.CrossesOverOrTouch:
                //    return FormatCrossMethodCall(twoArgumentCondition.Arg1, twoArgumentCondition.Arg2, "core.crossesOverOrTouch");
                case ConditionType.CrossesUnder:
                    return FormatCrossMethodCall(twoArgumentCondition.Arg1, twoArgumentCondition.Arg2, "crossunder");
                //case ConditionType.CrossesUnderOrTouch:
                //    return FormatCrossMethodCall(twoArgumentCondition.Arg1, twoArgumentCondition.Arg2, "core.crossesUnderOrTouch");
                case ConditionType.Greater:
                    return FormatComparison(twoArgumentCondition.Arg1, twoArgumentCondition.Arg2, ">");
                case ConditionType.Lesser:
                    return FormatComparison(twoArgumentCondition.Arg1, twoArgumentCondition.Arg2, "<");
                case ConditionType.GreaterOrEqual:
                    return FormatComparison(twoArgumentCondition.Arg1, twoArgumentCondition.Arg2, ">=");
                case ConditionType.LesserOrEqual:
                    return FormatComparison(twoArgumentCondition.Arg1, twoArgumentCondition.Arg2, "<=");
                case ConditionType.Equal:
                    return FormatComparison(twoArgumentCondition.Arg1, twoArgumentCondition.Arg2, "==");
                case ConditionType.NotEqual:
                    return FormatComparison(twoArgumentCondition.Arg1, twoArgumentCondition.Arg2, "!=");
                case ConditionType.And:
                    {
                        var multiArgumentCondition = condition as MultiArgumentCondition;
                        return "(" + string.Join(" and ", multiArgumentCondition.Subconditions.Select(c => FormatCondition(c))) + ")";
                    }
                case ConditionType.Or:
                    {
                        var multiArgumentCondition = condition as MultiArgumentCondition;
                        return "(" + string.Join(" or ", multiArgumentCondition.Subconditions.Select(c => FormatCondition(c))) + ")";
                    }
            }
            throw new NotSupportedConditionException(condition.ConditionType, "Pine Script");
        }

        private static string FormatComparison(MetaFormulaItem arg1, MetaFormulaItem arg2, string v)
        {
            return FormatStreamName(arg1) + $" {v} " + FormatStreamName(arg2);
        }

        private static string FormatStreamName(MetaFormulaItem arg)
        {
            return SourceFormatter.FormatSource(arg, "close");
        }

        private static string FormatCrossMethodCall(MetaFormulaItem arg1, MetaFormulaItem arg2, string methodName)
        {
            return $"{methodName}({FormatStreamName(arg1)}, {FormatStreamName(arg2)})";
        }
    }
}
