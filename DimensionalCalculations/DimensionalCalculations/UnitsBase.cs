using DimensionalCalculations.Units;
using DimensionalCalculations.Units.UnitsAmountOfSubstance;
using DimensionalCalculations.Units.UnitsCurrent;
using DimensionalCalculations.Units.UnitsEnergy;
using DimensionalCalculations.Units.UnitsForce;
using DimensionalCalculations.Units.UnitsLength;
using DimensionalCalculations.Units.UnitsLuminousIntensity;
using DimensionalCalculations.Units.UnitsMass;
using DimensionalCalculations.Units.UnitsPower;
using DimensionalCalculations.Units.UnitsTemperature;
using DimensionalCalculations.Units.UnitsTime;

namespace DimensionalCalculations
{
    public static partial class UnitsBase
    {
        #region All units

        private static Dictionary<Type, string[]> _unitsDict =
            new Dictionary<Type, string[]>()
        { 
            #region Base units 
 
            #region Amount of substance 
 
            { typeof(Mole), new string[]{ "mol", "моль" } }, 
 
            #endregion 
 
            #region Current 
 
            { typeof(Ampere), new string[]{ "A", "А" } }, 
 
            #endregion 
 
            #region Length 
 
            { typeof(Meter), new string[]{ "m", "м" } },
            { typeof(Mile), new string[]{ "mi", "миля" } }, 
 
            #endregion 
 
            #region Luminous intensity 
 
            { typeof(Candela), new string[]{ "cd", "кд" } }, 
 
            #endregion 
 
            #region Mass 
 
            { typeof(Carat), new string[]{ "ct", "кар" } },
            { typeof(Gram),  new string[]{ "g", "г" } }, 
            { typeof(Pound), new string[]{ "lb" } }, 
 
            #endregion 
 
            #region Temperature 
 
            { typeof(Celsius), new string[]{ "C", "С" } },
            { typeof(Kelvin), new string[]{ "K", "К" } },
            { typeof(Fahrenheit), new string[]{ "F" } }, 
 
            #endregion 
 
            #region Time 
 
            { typeof(Second), new string[]{ "s", "с" } },

            #endregion

            #endregion

            #region Complex units 

            #region Force

            { typeof(Newton), new string[]{ "N", "Н" } },
            { typeof(Dyne), new string[] { "dyn", "дина" } },

            #endregion

            #region Power

            { typeof(Watt), new string[]{ "W", "Вт" } },
            { typeof(Horsepower), new string[] { "hp", "лс" } },

            #endregion

            #region Energy

            { typeof(Joule), new string[]{ "J", "Дж" } },
            { typeof(Erg), new string[] { "erg", "эрг" } },
            { typeof(Electronvolt), new string[] { "eV", "эВ" } },

            #endregion

            #endregion
        };

        #endregion

        private static Dictionary<string, AbstractUnit> _units = 
            new Dictionary<string, AbstractUnit>();

        public static AbstractUnit GetAbstractUnit(Type unitType)
        {
            string abbrevation = _unitsDict[unitType].First();
            return GetAbstractUnit(abbrevation);
        }

        public static AbstractUnit GetAbstractUnit(string unitAbbrevation)
        {
            if (_units.ContainsKey(unitAbbrevation))
            {
                return _units[unitAbbrevation];
            }
            else
            {
                // Is simple unit (w/o metric prefix)
                foreach (var item in _unitsDict)
                {
                    string[] unitAbbrevations = item.Value;

                    if (unitAbbrevations.Contains(unitAbbrevation))
                    {
                        Type unitType = item.Key;
                        _units[unitAbbrevation] = (AbstractUnit)Activator.CreateInstance(unitType);
                        return _units[unitAbbrevation];
                    }
                }

                // Is complex unit (with metric prefix)
                foreach (var item in _unitsDict)
                {
                    string[] unitAbbrevations = item.Value;

                    // TODO: Check if similarAbbrevation is the only one....
                    IEnumerable<string> similarAbbrevations = unitAbbrevations
                        .Where(abb => unitAbbrevation.EndsWith(abb));

                    if (similarAbbrevations.Count() >= 1)
                    {
                        string similarAbbrevation = similarAbbrevations.First();
                        string abbrevationStart = unitAbbrevation.Substring(0, unitAbbrevation.Length - similarAbbrevation.Length);
                        if (MetricPrefixes.IsMetricPrefix(abbrevationStart))
                        {
                            MetricPrefix prefix = MetricPrefixes.GetMetricPrefix(abbrevationStart);
                            Type unitType = item.Key;
                            AbstractUnit unit = (AbstractUnit)Activator.CreateInstance(unitType);
                            _units[unitAbbrevation] = ApplyMetricPrefix(unit, prefix);

                            return _units[unitAbbrevation];
                        }
                    }
                }
            }

            throw new Exception($"Units' abbrevations dictionary does not contain string {unitAbbrevation}");
        }

        // HACK: DRY violation
        private static AbstractUnit ApplyMetricPrefix(AbstractUnit unit, MetricPrefix metricPrefix)
        {
            int power = MetricPrefixes.GetMetricPrefixPower(metricPrefix);
            return new MetricPrefixDecorator(unit, power);
        }

        public static IEnumerable<string> GetAllUnitAbbrevations()
        {
            List<string> allAbbrevations = new List<string>();

            foreach (string[] abbrevations in _unitsDict.Values)
            {
                allAbbrevations.AddRange(abbrevations);
            }

            return allAbbrevations;
        }

        public static string GetAlias(Type unit)
        {
            return _unitsDict[unit].First();
        }

        public static IEnumerable<AbstractUnit> GetUnits(SystemOfUnits system)
        {
            IEnumerable<AbstractUnit> output = null;

            switch (system)
            {
                case SystemOfUnits.SystemInternational:
                    output = new List<AbstractUnit>()
                    {
                        GetAbstractUnit("m"),
                        GetAbstractUnit("kg"),
                        GetAbstractUnit("s"),
                        GetAbstractUnit("mol"),
                        GetAbstractUnit("cd"),
                        GetAbstractUnit("A"),
                        GetAbstractUnit("K"),

                        GetAbstractUnit("N"),
                        GetAbstractUnit("J"),
                        GetAbstractUnit("W"),
                    };
                    break;
                case SystemOfUnits.SGS:
                    output = new List<AbstractUnit>()
                    {
                        new MetricPrefixDecorator(new Meter(), -2),
                        new Gram(),
                        new Second(),
                    };
                    break;
            }

            return output;
        }
    }
}