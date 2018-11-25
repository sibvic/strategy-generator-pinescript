using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ProfitRobots.StrategyGenerator.Model;

namespace ProfitRobots.StrategyGenerator.PineScript
{
    class SourceFormatter
    {
        /// <summary>
        /// Generate code for indicator source.
        /// </summary>
        /// <param name="source">Source</param>
        /// <exception cref="NotSupportedSourceException">When indicator is not supported.</exception>
        /// <returns>Generated code</returns>
        public static string Generate(IndicatorSource source)
        {
            switch (source.Name.ToUpper())
            {
                case "MVA":
                    {
                        var period = GetIntParamValue(source.Parameters, "period", 7, 0);
                        return $"{source.Id} = sma({FormatSource(source.Source, "close")}, {period})";
                    }
                case "RSI":
                    {
                        var period = GetIntParamValue(source.Parameters, "period", 7, 0);
                        return $"{source.Id} = rsi({FormatSource(source.Source, "close")}, {period})";
                    }
                case "MACD":
                    {
                        var fastlen = GetIntParamValue(source.Parameters, "fastlen", 12, 0);
                        var slowlen = GetIntParamValue(source.Parameters, "slowlen", 26, 1);
                        var siglen = GetIntParamValue(source.Parameters, "siglen", 9, 2);
                        return $"[{source.Id}_macd, {source.Id}_signal, {source.Id}_hist] = macd({FormatSource(source.Source, "close")}, {fastlen}, {slowlen}, {siglen})";
                    }
                case "STOCHASTIC":
                    {
                        var close = FormatSource(source.Source, "close");
                        var high = FormatSource(source.Source, "high");
                        var low = FormatSource(source.Source, "low");
                        var length = GetIntParamValue(source.Parameters, "length", 3, 0);
                        var periodK = GetIntParamValue(source.Parameters, "periodK", 5, 1);
                        var periodD = GetIntParamValue(source.Parameters, "periodD", 3, 2);
                        return new StringBuilder()
                            .AppendLine($"{source.Id}_k = sma(stoch({close}, {high}, {low}, {length}), {periodK})")
                            .Append($"{source.Id}_d = sma({source.Id}_k, {periodD})")
                            .ToString();
                    }
                case "BB":
                    {
                        var period = GetIntParamValue(source.Parameters, "period", 20, 0);
                        var dev = GetDoubleParamValue(source.Parameters, "dev", 2.0, 1);
                        return new StringBuilder()
                            .AppendLine($"{source.Id}_middle_band = sma(close, {period})")
                            .AppendLine($"{source.Id}_sma_deviation = {dev} * stdev(close, {period})")
                            .AppendLine($"{source.Id}_TL = {source.Id}_middle_band + {source.Id}_sma_deviation")
                            .Append($"{source.Id}_BL = {source.Id}_middle_band - {source.Id}_sma_deviation")
                            .ToString();
                    }
                case "SAR":
                    {
                        var step = GetDoubleParamValue(source.Parameters, "step", 0.02, 0);
                        var max = GetDoubleParamValue(source.Parameters, "max", 0.2, 1);
                        return $"{source.Id} = sar({step}, {step}, {max})";
                    }
                case "ATR":
                    {
                        var period = GetIntParamValue(source.Parameters, "period", 14, 0);
                        return $"{source.Id} = atr({period})";
                    }
                case "CCI":
                    {
                        var period = GetIntParamValue(source.Parameters, "period", 14, 0);
                        return $"{source.Id} = cci({FormatSource(source.Source, "close")}, {period})";
                    }
                case "EMA":
                    {
                        var period = GetIntParamValue(source.Parameters, "period", 10, 0);
                        return $"{source.Id} = ema({FormatSource(source.Source, "close")}, {period})";
                    }
                case "SWMA":
                    {
                        return $"{source.Id} = swma({FormatSource(source.Source, "close")})";
                    }
                case "TSI":
                    {
                        var shortPeriod = GetIntParamValue(source.Parameters, "shortPeriod", 7, 0);
                        var longPeriod = GetIntParamValue(source.Parameters, "longPeriod", 14, 0);
                        return $"{source.Id} = tsi({FormatSource(source.Source, "close")}, {shortPeriod}, {longPeriod})";
                    }
                case "VWAP":
                    {
                        return $"{source.Id} = vwap({FormatSource(source.Source, "close")})";
                    }
                case "VWMA":
                    {
                        var period = GetIntParamValue(source.Parameters, "period", 15, 0);
                        return $"{source.Id} = vwma({FormatSource(source.Source, "close")}, {period})";
                    }
                case "WMA":
                    {
                        var period = GetIntParamValue(source.Parameters, "period", 14, 0);
                        return $"{source.Id} = wma({FormatSource(source.Source, "close")}, {period})";
                    }
            }
            throw new NotSupportedSourceException($"Indicator {source.Name} is not supporeted in Pine Script yet");
        }

        private static string FormatDouble(double value)
        {
            return value.ToString("0.0#", CultureInfo.InvariantCulture);
        }

        private static string GetDoubleParamValue(List<IParameter> parameters, string paramName, double defaultValue, int index)
        {
            if (parameters == null)
                return FormatDouble(defaultValue);
            var doubleParams = parameters.Where(p => p.ParameterType == ParameterType.Double || p.ParameterType == ParameterType.External).ToList();
            var periodParam = doubleParams.Where(p => p.Id?.ToUpper() == paramName.ToUpper()).FirstOrDefault()
                ?? parameters.Skip(index).FirstOrDefault();
            switch (periodParam)
            {
                case ExternalParameter externalParam:
                    return externalParam.Value;
                case DoubleParameter doubleParam:
                    return FormatDouble(doubleParam.Value);
                case null:
                default:
                    return FormatDouble(defaultValue);

            }
        }

        private static string GetIntParamValue(List<IParameter> parameters, string paramName, int defaultValue, int index)
        {
            if (parameters == null)
                return defaultValue.ToString();
            var intParams = parameters.Where(p => p.ParameterType == ParameterType.Integer || p.ParameterType == ParameterType.External).ToList();
            var periodParam = intParams.Where(p => p.Id?.ToUpper() == paramName.ToUpper()).FirstOrDefault()
                ?? parameters.Skip(index).FirstOrDefault();
            switch (periodParam)
            {
                case ExternalParameter externalParam:
                    return externalParam.Value;
                case IntParameter intParam:
                    return intParam.Value.ToString();
                case null:
                default:
                    return defaultValue.ToString();
            }
        }

        private static List<IMetaSource> SortSources(List<IMetaSource> sources)
        {
            var result = new List<IMetaSource>();

            IMetaSource GetNextSource()
            {
                foreach (var source in sources)
                {
                    switch (source)
                    {
                        case IndicatorSource indicatorSource:
                            {
                                if (indicatorSource.Source.Value == null)
                                    return source;
                                if (result.Any(s => s.Id == indicatorSource.Source.Value))
                                    return source;
                            }
                            break;
                        default:
                            return source;
                    }
                }
                return null;
            }

            while (sources.Any())
            {
                var source = GetNextSource();
                sources.Remove(source);
                result.Add(source);
            }
            return result;
        }

        /// <summary>
        /// Generate code for the sources.
        /// </summary>
        /// <param name="sources">Sources</param>
        /// <exception cref="NotSupportedSourceException">When source is not supported.</exception>
        /// <returns>Generated code</returns>
        internal static string GenerateCode(List<IMetaSource> sources)
        {
            StringBuilder res = new StringBuilder();
            foreach (var source in SortSources(sources))
            {
                res.AppendLine(Generate(source));
            }
            return res.ToString();
        }

        /// <summary>
        /// Generate code for the source.
        /// </summary>
        /// <param name="source">Source</param>
        /// <exception cref="NotSupportedSourceException">When source is not supported.</exception>
        /// <returns>Generated code</returns>
        internal static string Generate(IMetaSource source)
        {
            switch (source)
            {
                case IndicatorSource indicatorSource:
                    return Generate(indicatorSource);
                case InstrumentSource instrumentSource:
                    return Generate(instrumentSource);
                case MainInstrumentSource mainInstrumentSource:
                default:
                    throw new NotSupportedSourceException(source.SourceType);
            }
        }

        private static string Generate(InstrumentSource instrumentSource)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{instrumentSource.Id}_open = security(tickerid, \"{instrumentSource.Timeframe}\", open)")
                .AppendLine($"{instrumentSource.Id}_high = security(tickerid, \"{instrumentSource.Timeframe}\", high)")
                .AppendLine($"{instrumentSource.Id}_low = security(tickerid, \"{instrumentSource.Timeframe}\", low)")
                .Append($"{instrumentSource.Id}_close = security(tickerid, \"{instrumentSource.Timeframe}\", close)");
            return sb.ToString();
        }

        public static string FormatSource(MetaFormulaItem source, string defaultSubstream)
        {
            if (source.StreamType == StreamType.Instrument)
            {
                if (source.Value == null && source.Substream == null)
                    return defaultSubstream;
                if (source.Substream == null)
                    return $"{source.Value}_{defaultSubstream}";
            }
            if (source.Value == null)
                return source.Substream.ToLower();
            var substream = string.IsNullOrEmpty(source.Substream) ? "" : "_" + source.Substream.ToLower();
            return source.Value + substream;
        }
    }
}
