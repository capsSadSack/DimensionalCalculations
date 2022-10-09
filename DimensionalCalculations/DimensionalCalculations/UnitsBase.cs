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


        public static AbstractUnit GetAbstractUnit(string unitAbbrevation)
        {
            foreach (var item in _unitsDict)
            {
                string[] unitAbbrevations = item.Value;

                if (unitAbbrevations.Contains(unitAbbrevation))
                {
                    Type unitType = item.Key;
                    return (AbstractUnit)Activator.CreateInstance(unitType);

                }
            }

            throw new Exception($"Units' abbrevations dictionary does not contain string {unitAbbrevation}");
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
                        new Meter(),
                        new MetricPrefixDecorator(new Gram(), 3),
                        new Second(),
                        new Mole(),
                        new Candela(),
                        new Ampere(),
                        new Kelvin(),
                        
                        new Newton(),
                        new Joule(),
                        new Watt()
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