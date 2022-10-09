namespace DimensionalCalculations.Units.UnitsTemperature
{
    public class Celsius : TemperatureUnit
    {
        private const double _TO_KELVIN_ADDITIVE = -273.15;

        public override double FromSI(double value)
        {
            return value + _TO_KELVIN_ADDITIVE;
        }

        public override double ToSI(double value)
        {
            return value - _TO_KELVIN_ADDITIVE;
        }
    }
}
