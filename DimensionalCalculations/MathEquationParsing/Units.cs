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
using MathEquationParsing.Models;

namespace MathEquationParsing
{
    internal static class Units
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

        public static AbstractUnit GetUnit(string str)
        {
            if(str == "")
            {
                return new DimensionlessUnit();
            }

            string[] parts = str.Split(' ')
                .Where(x => x.Length > 0)
                .ToArray();
            AbstractUnit output = new DimensionlessUnit();

            foreach (string part in parts)
            {
                AbstractUnit unit = ParseSingleUnit(part);

                // TODO: [CG, 2022.08.02] Заглушка, чтобы проходили тесты в простейшем варианте
                output = unit;
            }

            return output;
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

                        if (IsMetricPrefix(metricPrefixStr))
                        {
                            MetricPrefix metricPrefix = GetMetricPrefix(metricPrefixStr);
                            AbstractUnit unit = GetAbstractUnit(abbrevation);

                            return ApplyMetricPrefix(unit, metricPrefix);
                        }
                    }
                }
            }

            // TODO: [CG, 2022.08.02] Конкретизировать exception
            throw new Exception();
        }

        private static AbstractUnit ApplyMetricPrefix(AbstractUnit unit, MetricPrefix metricPrefix)
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

            // TODO: [CG, 2022.08.02] Конкретизировать exception
            throw new Exception();
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

        private static MetricPrefix GetMetricPrefix(string metricPrefixStr)
        {
            foreach(var item in _metricPrefixesDict)
            {
                string[] metricPrefixes = item.Value;

                if(metricPrefixes.Contains(metricPrefixStr))
                {
                    return item.Key;
                }
            }

            // TODO: [CG, 2022.08.02] Конкретизировать exception
            throw new Exception();
        }

        private static bool IsMetricPrefix(string str)
        {
            IEnumerable<string> allMetricPrefixes = GetAllMetricPrefixes();

            foreach (string prefix in allMetricPrefixes)
            {
                if(str == prefix)
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
