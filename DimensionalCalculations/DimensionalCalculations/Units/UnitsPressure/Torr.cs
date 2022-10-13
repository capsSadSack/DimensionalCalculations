namespace DimensionalCalculations.Units.UnitsPressure
{
    public class Torr : PressureUnit
    {
        private const double _1_TORR_IN_Pa = 133.322368421;

        public override double FromSI(double value)
        {
            return value / _1_TORR_IN_Pa;
        }

        public override double ToSI(double value)
        {
            return _1_TORR_IN_Pa * value;
        }
    }
}
