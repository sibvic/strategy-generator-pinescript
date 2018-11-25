using System.Collections.Generic;
using System.Text;
using ProfitRobots.StrategyGenerator.Model;

namespace ProfitRobots.StrategyGenerator.PineScript
{
    /// <summary>
    /// Formats parameters in Pine Script
    /// </summary>
    class ParametersFormatter
    {
        /// <summary>
        /// Generate code for the parameters.
        /// </summary>
        /// <exception cref="NotSupportedParameterException">On unsupported parameter type</exception>
        /// <param name="parameters">Parameters</param>
        /// <returns>Generated code</returns>
        internal static string GenerateCode(List<IParameter> parameters)
        {
            var code = new StringBuilder();
            foreach (var param in parameters)
            {
                switch (param)
                {
                    case IntParameter intParam:
                        code.AppendLine($"{param.Id} = input({intParam.Value.FormatConst()}, {param.Name.FormatConst()}, integer)");
                        break;
                    case BoolParameter boolParam:
                        code.AppendLine($"{param.Id} = input({boolParam.Value.FormatConst()}, {param.Name.FormatConst()}, bool)");
                        break;
                    case DoubleParameter doubleParam:
                        code.AppendLine($"{param.Id} = input({doubleParam.Value.FormatConst()}, {param.Name.FormatConst()}, float)");
                        break;
                    case PriceParameter priceParam:
                        code.AppendLine($"{param.Id} = input({priceParam.Value.FormatConst()}, {param.Name.FormatConst()}, float)");
                        break;
                    case PriceTypeParameter priceTypeParam:
                        //ignore
                        break;
                    default:
                        throw new NotSupportedParameterException(param.ParameterType, "Pine Script");
                }
            }
            return code.ToString();
        }
    }
}
