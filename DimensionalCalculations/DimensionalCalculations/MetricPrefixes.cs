using DimensionalCalculations.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations
{
    public static class MetricPrefixes
    {
        private static readonly IEnumerable<(MetricPrefix prefix, int power, string[] aliases)> _prefixes =
            new List<(MetricPrefix prefix, int power, string[] aliases)>()
            {

        #region Multiple

        (MetricPrefix.Deca,   1, new string[] { "da", "да" }),
        (MetricPrefix.Hecto,  2, new string[] { "h", "г"  }),
        (MetricPrefix.Kilo,   3, new string[] { "k", "к" }),
        (MetricPrefix.Mega,   6, new string[] { "M", "М" }),
        (MetricPrefix.Giga,   9, new string[] { "G", "Г" }),
        (MetricPrefix.Tera,  12, new string[] { "T", "Т" }),
        (MetricPrefix.Peta,  15, new string[] { "P", "П" }),
        (MetricPrefix.Exa,   18, new string[] { "E", "Э" }),
        (MetricPrefix.Zetta, 21, new string[] { "Z", "З" }),
        (MetricPrefix.Yotta, 24, new string[] { "Y", "И" }),

        #endregion

        #region Submultiple

        (MetricPrefix.Deca,   -1, new string[] { "d", "д" }),
        (MetricPrefix.Centi,  -2, new string[] { "c", "с" }),
        (MetricPrefix.Milli,  -3, new string[] { "m", "м" }),
        (MetricPrefix.Micro,  -6, new string[] { "u", "μ", "мк" }),
        (MetricPrefix.Nano,   -9, new string[] { "n", "н" }),
        (MetricPrefix.Pico,  -12, new string[] { "p", "п" }),
        (MetricPrefix.Femto, -15, new string[] { "f", "ф" }),
        (MetricPrefix.Atto,  -18, new string[] { "a", "а" }),
        (MetricPrefix.Zepto, -21, new string[] { "z", "з" }),
        (MetricPrefix.Yocto, -24, new string[] { "y", "и" }),

        #endregion

            };

        public static string[] GetMetricPrefixAliases(MetricPrefix metricPrefix)
        {
            return _prefixes.Where(x => x.prefix == metricPrefix)
                .First()
                .aliases;
        }

        public static int GetMetricPrefixPower(MetricPrefix metricPrefix)
        {
            return _prefixes.Where(x => x.prefix == metricPrefix)
                .First()
                .power;
        }

        public static MetricPrefix GetMetricPrefix(int powerOfTen)
        {
            if(powerOfTen == 0)
            {
                return MetricPrefix.None;
            }

            return _prefixes.Where(x => x.power == powerOfTen)
                .First().prefix;
        }

        public static MetricPrefix GetMetricPrefix(string metricPrefixStr)
        {
            foreach (var item in _prefixes)
            {
                string[] metricPrefixes = item.aliases;

                if (metricPrefixes.Contains(metricPrefixStr))
                {
                    return item.prefix;
                }
            }

            throw new IncorrectMetricPrefixException($"Unknown metric prefix: \"{metricPrefixStr}\".");
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

                foreach (string[] prefixes in _prefixes.Select(x => x.aliases))
                {
                    allPrefixes.AddRange(prefixes);
                }

                _allMetricPrefixes = allPrefixes;
            }

            return _allMetricPrefixes;
        }
    }
}
