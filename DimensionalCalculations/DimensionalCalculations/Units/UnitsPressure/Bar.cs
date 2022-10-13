namespace DimensionalCalculations.Units.UnitsPressure
{
    public class Bar : PressureUnit
    {
        private const double _1_BAR_IN_Pa = 1e5;

        public override double FromSI(double value)
        {
            return value / _1_BAR_IN_Pa;
        }

        public override double ToSI(double value)
        {
            return _1_BAR_IN_Pa * value;
        }
    }
}
