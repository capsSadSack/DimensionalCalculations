using DimensionalCalculations;
using MathEquationParsing.Exceptions;
using MathEquationParsing.Models;
using UnitsLib;

namespace MathEquationParsing
{
    /// <summary>
    /// Single unit parsing like 'kg', 'km'
    /// </summary>
    public static class SingleUnitParsing
    {

        public static AbstractUnit ParseSingleUnit(string str)
        {
            IOrderedEnumerable<string> allUnitAbbrevationsFromLongest = GetAllUnitAbbrevationsFromLongest();

            foreach (string abbrevation in allUnitAbbrevationsFromLongest)
            {

                if (str == abbrevation)
                {
                    return Units.GetAbstractUnit(abbrevation);
                }
                else if (str.EndsWith(abbrevation))
                {
                    if (str.Length > abbrevation.Length)
                    {
                        string metricPrefixStr = str.Substring(0, str.Length - abbrevation.Length);

                        if (MetricPrefixParsing.IsMetricPrefix(metricPrefixStr))
                        {
                            MetricPrefix metricPrefix = MetricPrefixParsing.GetMetricPrefix(metricPrefixStr);
                            AbstractUnit unit = Units.GetAbstractUnit(abbrevation);

                            return MetricPrefixParsing.ApplyMetricPrefix(unit, metricPrefix);
                        }
                    }
                }
            }

            throw new IncorrectUnitException($"Unable to parse string \"{str}\" to unit.");
        }


        private static IOrderedEnumerable<string> _allUnitAbbrevationsFromLongest = null;

        private static IOrderedEnumerable<string> GetAllUnitAbbrevationsFromLongest()
        {
            if (_allUnitAbbrevationsFromLongest == null)
            {
                IEnumerable<string> allUnitAbbrevations = Units.GetAllUnitAbbrevations();
                _allUnitAbbrevationsFromLongest = allUnitAbbrevations.OrderByDescending(x => x.Length);
            }

            return _allUnitAbbrevationsFromLongest;
        }
    }
}
