namespace DimensionalCalculations.Units.UnitsLength
{
    public class LightYear : LengthUnit
    {
        private const double _1_LY_EQUALS_m = 9.4607E15;

        public override double FromSI(double value)
        {
            return value / _1_LY_EQUALS_m;
        }

        public override double ToSI(double value)
        {
            return value * _1_LY_EQUALS_m;
        }
    }
}
