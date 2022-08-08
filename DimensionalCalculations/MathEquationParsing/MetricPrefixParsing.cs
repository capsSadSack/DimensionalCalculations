using DimensionalCalculations;
using DimensionalCalculations.Units;
using MathEquationParsing.Exceptions;
using MathEquationParsing.Models;

namespace MathEquationParsing
{
    public static class MetricPrefixParsing
    {
        private static Dictionary<MetricPrefix, string[]> _metricPrefixesDict =
            new Dictionary<MetricPrefix, string[]>()
        {
                #region Multiple

                { MetricPrefix.Deca,  new string[]{ "da", "да" } },
                { MetricPrefix.Hecto, new string[]{ "h", "г" } },
                { MetricPrefix.Kilo,  new string[]{ "k", "к" } },
                { MetricPrefix.Mega,  new string[]{ "M", "М" } },
                { MetricPrefix.Giga,  new string[]{ "G", "Г" } },
                { MetricPrefix.Tera,  new string[]{ "T", "Т" } },
                { MetricPrefix.Peta,  new string[]{ "P", "П" } },
                { MetricPrefix.Exa,   new string[]{ "E", "Э" } },
                { MetricPrefix.Zetta, new string[]{ "Z", "З" } },
                { MetricPrefix.Yotta, new string[]{ "Y", "И" } },

                #endregion

                #region Submultiple

                { MetricPrefix.Deci,  new string[]{ "d", "д" } },
                { MetricPrefix.Centi, new string[]{ "c", "с" } },
                { MetricPrefix.Milli, new string[]{ "m", "м" } },
                { MetricPrefix.Micro, new string[]{ "u", "μ", "мк" } },
                { MetricPrefix.Nano,  new string[]{ "n", "н" } },
                { MetricPrefix.Pico,  new string[]{ "p", "п" } },
                { MetricPrefix.Femto, new string[]{ "f", "ф" } },
                { MetricPrefix.Atto,  new string[]{ "a", "а" } },
                { MetricPrefix.Zepto, new string[]{ "z", "з" } },
                { MetricPrefix.Yocto, new string[]{ "y", "и" } }

            #endregion
        };

        public static AbstractUnit ApplyMetricPrefix(AbstractUnit unit, MetricPrefix metricPrefix)
        {
            switch (metricPrefix)
            {
                #region Multiple

                case MetricPrefix.Deca: return new MetricPrefixDecorator(unit, 1);
                case MetricPrefix.Hecto: return new MetricPrefixDecorator(unit, 2);
                case MetricPrefix.Kilo: return new MetricPrefixDecorator(unit, 3);
                case MetricPrefix.Mega: return new MetricPrefixDecorator(unit, 6);
                case MetricPrefix.Giga: return new MetricPrefixDecorator(unit, 9);
                case MetricPrefix.Tera: return new MetricPrefixDecorator(unit, 12);
                case MetricPrefix.Peta: return new MetricPrefixDecorator(unit, 15);
                case MetricPrefix.Exa: return new MetricPrefixDecorator(unit, 18);
                case MetricPrefix.Zetta: return new MetricPrefixDecorator(unit, 21);
                case MetricPrefix.Yotta: return new MetricPrefixDecorator(unit, 24);

                #endregion

                #region Submultiple

                case MetricPrefix.Deci: return new MetricPrefixDecorator(unit, -1);
                case MetricPrefix.Centi: return new MetricPrefixDecorator(unit, -2);
                case MetricPrefix.Milli: return new MetricPrefixDecorator(unit, -3);
                case MetricPrefix.Micro: return new MetricPrefixDecorator(unit, -6);
                case MetricPrefix.Nano: return new MetricPrefixDecorator(unit, -9);
                case MetricPrefix.Pico: return new MetricPrefixDecorator(unit, -12);
                case MetricPrefix.Femto: return new MetricPrefixDecorator(unit, -15);
                case MetricPrefix.Atto: return new MetricPrefixDecorator(unit, -18);
                case MetricPrefix.Zepto: return new MetricPrefixDecorator(unit, -21);
                case MetricPrefix.Yocto: return new MetricPrefixDecorator(unit, -24);

                    #endregion
            }

            throw new IncorrectMetricPrefixException($"It was not declared how to parse metric prefix { metricPrefix }.");
        }

        public static MetricPrefix GetMetricPrefix(string metricPrefixStr)
        {
            foreach (var item in _metricPrefixesDict)
            {
                string[] metricPrefixes = item.Value;

                if (metricPrefixes.Contains(metricPrefixStr))
                {
                    return item.Key;
                }
            }

            throw new IncorrectMetricPrefixException($"Unknown metric prefix: \"{ metricPrefixStr }\".");
        }

        public static bool IsMetricPrefix(string str)
        {
            IEnumerable<string> allMetricPrefixes = GetAllMetricPrefixes();

            foreach (string prefix in allMetricPrefixes)
            {
                if (str == prefix)
                {
                    return true;
                }
            }

            return false;
        }


        private static IEnumerable<string> _allMetricPrefixes = null;

        private static IEnumerable<string> GetAllMetricPrefixes()
        {
            if (_allMetricPrefixes == null)
            {
                List<string> allPrefixes = new List<string>();

                foreach (string[] prefixes in _metricPrefixesDict.Values)
                {
                    allPrefixes.AddRange(prefixes);
                }

                _allMetricPrefixes = allPrefixes;
            }

            return _allMetricPrefixes;
        }
    }
}
