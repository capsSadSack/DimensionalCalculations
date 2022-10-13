namespace DimensionalCalculations.Units.UnitsVolume
{
    public class Barrel : VolumeUnit
    {
        private const double _1_BARREL_IN_m3 = 0.158988;

        public override double FromSI(double value)
        {
            return value / _1_BARREL_IN_m3;
        }

        public override double ToSI(double value)
        {
            return _1_BARREL_IN_m3 * value;
        }
    }
}
