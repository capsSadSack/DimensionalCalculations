namespace DimensionalCalculations.Units.UnitsTemperature
{
    public class Fahrenheit : TemperatureUnit
    {
        private const double _FROM_CELSIUS_MULTIPLIER = 1.8;
        private const double _FROM_CELSIUS_ADDITIVE = 32;
        private const double _TO_KELVIN_ADDITIVE = -273.15;

        public override double FromSI(double value)
        {
            return (value + _TO_KELVIN_ADDITIVE) * _FROM_CELSIUS_MULTIPLIER + _FROM_CELSIUS_ADDITIVE;
        }

        public override double ToSI(double value)
        {
            return (value - _FROM_CELSIUS_ADDITIVE) / _FROM_CELSIUS_MULTIPLIER - _TO_KELVIN_ADDITIVE;
        }
    }
}
