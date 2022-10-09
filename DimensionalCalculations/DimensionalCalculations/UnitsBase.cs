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

                #region Force

                { new Newton(), new string[]{ "N", "Н" } },
                { new Dyne(), new string[] { "dyn", "дина" } },

                #endregion

                #region Power

                { new Watt(), new string[]{ "W", "Вт" } },
                { new Horsepower(), new string[] { "hp", "лс" } },

                #endregion

                #region Energy

                { new Joule(), new string[]{ "J", "Дж" } },
                { new Erg(), new string[] { "erg", "эрг" } },
                { new Electronvolt(), new string[] { "eV", "эВ" } },

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
                    return item.Key;
                }
            }

            throw new Exception($"Units' abbrevations dictionary does not contain string {unitAbbrevation}");
        }

        public static IEnumerable<AbstractUnit> GetAllUnits()
        {
            return _unitsDict.Keys;
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
    }
}