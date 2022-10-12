namespace DimensionalCalculations.Units.UnitsVolume
{
    public class Pint : VolumeUnit
    {
        private const double _1_PINT_IN_m3 = 0.568e-3;

        public override double FromSI(double value)
        {
            return value / _1_PINT_IN_m3;
        }

        public override double ToSI(double value)
        {
            return _1_PINT_IN_m3 * value;
        }
    }
}
