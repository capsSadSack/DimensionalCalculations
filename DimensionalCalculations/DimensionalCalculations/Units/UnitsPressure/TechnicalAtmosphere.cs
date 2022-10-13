namespace DimensionalCalculations.Units.UnitsPressure
{
    public class TechnicalAtmosphere : PressureUnit
    {
        private const double _1_AT_IN_Pa = 98066.5;

        public override double FromSI(double value)
        {
            return value / _1_AT_IN_Pa;
        }

        public override double ToSI(double value)
        {
            return _1_AT_IN_Pa * value;
        }
    }
}
