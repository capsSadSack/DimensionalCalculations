namespace DimensionalCalculations.Units.UnitsLength
{
    public class Angstrem : LengthUnit
    {
        private const double _1_A_EQUALS_m = 1e-10;

        public override double FromSI(double value)
        {
            return value / _1_A_EQUALS_m;
        }

        public override double ToSI(double value)
        {
            return value * _1_A_EQUALS_m;
        }
    }
}
