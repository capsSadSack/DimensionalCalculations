namespace DimensionalCalculations.Units.UnitsPressure
{
    public class StandardAtmosphere : PressureUnit
    {
        private const double _1_ATM_IN_Pa = 101325;

        public override double FromSI(double value)
        {
            return value / _1_ATM_IN_Pa;
        }

        public override double ToSI(double value)
        {
            return _1_ATM_IN_Pa * value;
        }
    }
}
