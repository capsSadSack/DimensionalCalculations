namespace DimensionalCalculations.Units.UnitsVolume
{
    public class Litre : VolumeUnit
    {
        private const double _1_L_IN_m3 = 1e-3;

        public override double FromSI(double value)
        {
            return value / _1_L_IN_m3;
        }

        public override double ToSI(double value)
        {
            return _1_L_IN_m3 * value;
        }
    }
}
