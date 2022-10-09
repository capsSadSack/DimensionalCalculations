using DimensionalCalculations;
using DimensionalCalculations.Units;
using MathEquationParsing.Exceptions;

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
                    return UnitsBase.GetAbstractUnit(abbrevation);
                }
                else if (str.EndsWith(abbrevation))
                {
                    if (str.Length > abbrevation.Length)
                    {
                        string metricPrefixStr = str.Substring(0, str.Length - abbrevation.Length);

                        if (MetricPrefixes.IsMetricPrefix(metricPrefixStr))
                        {
                            MetricPrefix metricPrefix = MetricPrefixes.GetMetricPrefix(metricPrefixStr);
                            AbstractUnit unit = UnitsBase.GetAbstractUnit(abbrevation);

                            return ApplyMetricPrefix(unit, metricPrefix);
                        }
                    }
                }
            }

            throw new IncorrectUnitException($"Unable to parse string \"{str}\" to unit.");
        }

        private static AbstractUnit ApplyMetricPrefix(AbstractUnit unit, MetricPrefix metricPrefix)
        {
            int power = MetricPrefixes.GetMetricPrefixPower(metricPrefix);
            return new MetricPrefixDecorator(unit, power);
        }

        private static IOrderedEnumerable<string> _allUnitAbbrevationsFromLongest = null;

        private static IOrderedEnumerable<string> GetAllUnitAbbrevationsFromLongest()
        {
            if (_allUnitAbbrevationsFromLongest == null)
            {
                IEnumerable<string> allUnitAbbrevations = UnitsBase.GetAllUnitAbbrevations();
                _allUnitAbbrevationsFromLongest = allUnitAbbrevations.OrderByDescending(x => x.Length);
            }

            return _allUnitAbbrevationsFromLongest;
        }
    }
}
