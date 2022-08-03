using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DimensionalCalculations;
using DimensionalCalculations.Units;
using DimensionalCalculations.Units.UnitsAmountOfSubstance;
using DimensionalCalculations.Units.UnitsCurrent;
using DimensionalCalculations.Units.UnitsLength;
using DimensionalCalculations.Units.UnitsLuminousIntensity;
using DimensionalCalculations.Units.UnitsMass;
using DimensionalCalculations.Units.UnitsTemperature;
using DimensionalCalculations.Units.UnitsTime;
using MathEquationParsing.Exceptions;
using MathEquationParsing.Models;

namespace MathEquationParsing
{
    public static class UnitParsing
    {
        private static Dictionary<AbstractUnit, string[]> _unitsDict =
            new Dictionary<AbstractUnit, string[]>()
        {
                #region Base units

                #region Amount of substance

                { new Mole(), new string[]{ "mol", "моль" } },

                #endregion

                #region Current

                { new Ampere(), new string[]{ "A", "А" } },

                #endregion

                #region Length

                { new Meter(), new string[]{ "m", "м" } },
                { new Mile(), new string[]{ "mi", "миля" } },

                #endregion

                #region Luminous intensity

                { new Candela(), new string[]{ "cd", "кд" } },

                #endregion

                #region Mass

                { new Carat(), new string[]{ "ct", "кар" } },
                { new Gram(),  new string[]{ "g", "г" } },
                //{ new Ounce(), new string[]{ "oz", "унция", "унц" } },
                { new Pound(), new string[]{ "lb" } },

                #endregion

                #region Temperature

                { new Celsius(), new string[]{ "C", "С" } },
                { new Kelvin(), new string[]{ "K", "К" } },
                { new Fahrenheit(), new string[]{ "F" } },

                #endregion

                #region Time

                { new Second(), new string[]{ "s", "с" } },

                #endregion

                #endregion

                #region Complex units



                #endregion
        };

        public static AbstractUnit GetUnit(string str)
        {
            if(str == "")
            {
                return new DimensionlessUnit();
            }

            if (!str.Contains('/'))
            {
                string[] parts = str.Split(' ')
                    .Where(x => x.Length > 0)
                    .ToArray();
                AbstractUnit output = new DimensionlessUnit();

                foreach (string part in parts)
                {
                    AbstractUnit unit = ParseSingleUnit(part);
                    output *= unit;
                }

                return output;
            }
            else
            {
                string[] fractionParts = str.Split('/')
                    .Where(x => x.Length > 0)
                    .ToArray();

                AbstractUnit dividend = GetUnit(fractionParts[0]);
                AbstractUnit divisor = GetUnit(fractionParts[1]);

                return dividend / divisor;
            }
        }

        private static AbstractUnit ParseSingleUnit(string str)
        {
            IOrderedEnumerable<string> allUnitAbbrevationsFromLongest = GetAllUnitAbbrevationsFromLongest();

            foreach(string abbrevation in allUnitAbbrevationsFromLongest)
            {
                
                if(str == abbrevation)
                {
                    return GetAbstractUnit(abbrevation);
                }
                else if (str.EndsWith(abbrevation))
                {
                    if (str.Length > abbrevation.Length)
                    {
                        string metricPrefixStr = str.Substring(0, str.Length - abbrevation.Length);

                        if (MetricPrefixParsing.IsMetricPrefix(metricPrefixStr))
                        {
                            MetricPrefix metricPrefix = MetricPrefixParsing.GetMetricPrefix(metricPrefixStr);
                            AbstractUnit unit = GetAbstractUnit(abbrevation);

                            return MetricPrefixParsing.ApplyMetricPrefix(unit, metricPrefix);
                        }
                    }
                }
            }

            throw new IncorrectUnitException($"Unable to parse string \"{ str }\" to unit.");
        }

        private static AbstractUnit GetAbstractUnit(string unitAbbrevation)
        {
            foreach (var item in _unitsDict)
            {
                string[] unitAbbrevations = item.Value;

                if (unitAbbrevations.Contains(unitAbbrevation))
                {
                    return item.Key;
                }
            }

            // TODO: [CG, 2022.08.02] Конкретизировать exception
            throw new Exception();
        }


        private static IOrderedEnumerable<string> _allUnitAbbrevationsFromLongest = null;

        private static IOrderedEnumerable<string> GetAllUnitAbbrevationsFromLongest()
        {
            if (_allUnitAbbrevationsFromLongest == null)
            {
                List<string> allAbbrevations = new List<string>();

                foreach (string[] abbrevations in _unitsDict.Values)
                {
                    allAbbrevations.AddRange(abbrevations);
                }

                _allUnitAbbrevationsFromLongest = allAbbrevations.OrderByDescending(x => x.Length);
            }

            return _allUnitAbbrevationsFromLongest;
        }
    }
}
