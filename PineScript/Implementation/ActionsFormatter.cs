using ProfitRobots.StrategyGenerator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfitRobots.StrategyGenerator.PineScript
{
    /// <summary>
    /// Formats actions.
    /// </summary>
    class ActionsFormatter
    {
        /// <summary>
        /// Generate code for actions
        /// </summary>
        /// <exception cref="NotSupportedFormulaItemException">Unsupported item in the formula</exception>
        /// <param name="actions">Actions</param>
        /// <returns>Generates code.</returns>
        public static string FormatActions(List<MetaAction> actions)
        {
            StringBuilder code = new StringBuilder();
            foreach (var action in actions)
            {
                switch (action.ActionType)
                {
                    case MetaActionType.Buy:
                        code.AppendLine("buy = " + ConditionFormatter.FormatCondition(action.Condition));
                        code.AppendLine($"strategy.entry(\"long\", strategy.long, when = buy)");
                        break;
                    case MetaActionType.Sell:
                        code.AppendLine("sell = " + ConditionFormatter.FormatCondition(action.Condition));
                        code.AppendLine($"strategy.entry(\"short\", strategy.short, when = sell)");
                        break;
                    case MetaActionType.ExitBuy:
                        code.AppendLine("exit_buy = " + ConditionFormatter.FormatCondition(action.Condition));
                        code.AppendLine($"strategy.close(\"long\", when = exit_buy)");
                        break;
                    case MetaActionType.ExitSell:
                        code.AppendLine("exit_sell = " + ConditionFormatter.FormatCondition(action.Condition));
                        code.AppendLine($"strategy.close(\"short\", when = exit_sell)");
                        break;
                    case MetaActionType.Exit:
                        code.AppendLine("exit_all = " + ConditionFormatter.FormatCondition(action.Condition));
                        code.AppendLine($"strategy.close_all(when = exit_all)");
                        break;
                    case MetaActionType.EntryBuy:
                        {
                            code.AppendLine("entry_buy = " + ConditionFormatter.FormatCondition(action.Condition));
                            (var value, var inPips) = FormatOrderValue(action.Entry);
                            code.AppendLine($"entry_buy_rate = {value}");
                            code.AppendLine($"strategy.order(\"entry buy\", true, stop = close > entry_buy_rate ? entry_buy_rate : NaN, limit = close < entry_buy_rate ? entry_buy_rate : NaN, when = entry_buy)");
                        }
                        break;
                    case MetaActionType.EntrySell:
                        {
                            code.AppendLine("entry_sell = " + ConditionFormatter.FormatCondition(action.Condition));
                            (var value, var inPips) = FormatOrderValue(action.Entry);
                            code.AppendLine($"entry_sell_rate = {value}");
                            code.AppendLine($"strategy.order(\"entry sell\", false, stop = close < entry_sell_rate ? entry_sell_rate : NaN, limit = close > entry_sell_rate ? entry_sell_rate : NaN, when = entry_sell)");
                        }
                        break;
                    default:
                        throw new NotSupportedActionException(action.ActionType, "Pine Script");
                }
            }
            return code.ToString();
        }

        /// <summary>
        /// Format order value
        /// </summary>
        /// <exception cref="NotSupportedFormulaItemException">Unsupported element in the value</exception>
        /// <param name="order">Order</param>
        /// <returns>Formatted value</returns>
        private static (string value, bool isValueInPips) FormatOrderValue(MetaOrder order)
        {
            if (order == null)
            {
                return (null, false);
            }
            StringBuilder formula = new StringBuilder();
            bool valueInPips = true;
            string lastOperation = null;
            foreach (var value in order.ValueStack)
            {
                switch (value.ValueType)
                {
                    case FormulaItemType.Operand:
                        formula.Append(value.Value);
                        lastOperation = value.Value;
                        break;
                    case FormulaItemType.Parameter:
                        switch (lastOperation)
                        {
                            case "-":
                            case "+":
                                throw new NotSupportedFormulaItemException(value.ValueType, "Pine Script");
                            default:
                                formula.Append($"{value.Value}");
                                break;
                        }
                        break;
                    case FormulaItemType.Stream:
                    case FormulaItemType.StreamValue:
                        if (string.IsNullOrEmpty(value.Substream))
                        {
                            formula.Append($"{value.Value}");
                        }
                        else
                        {
                            if (value.Value == null && value.StreamType == StreamType.Instrument)
                                formula.Append($"{value.Substream}");
                            else
                                formula.Append($"{value.Value}_{value.Substream}");
                        }
                        valueInPips = false;
                        break;
                    case FormulaItemType.Value:
                        switch (lastOperation)
                        {
                            case "-":
                            case "+":
                                throw new NotSupportedFormulaItemException(value.ValueType, "Pine Script");
                            default:
                                formula.Append($"{value.Value}");
                                break;
                        }
                        break;
                }
            }
            return (formula.ToString(), valueInPips);
        }
    }
}
