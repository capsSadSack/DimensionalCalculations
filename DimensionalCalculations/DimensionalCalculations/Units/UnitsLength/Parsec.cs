namespace DimensionalCalculations.Units.UnitsLength
{
    public class Parsec : LengthUnit
    {
        private const double _1_PC_EQUALS_m = 3.0857E16;

        public override double FromSI(double value)
        {
            return value / _1_PC_EQUALS_m;
        }

        public override double ToSI(double value)
        {
            return value * _1_PC_EQUALS_m;
        }
    }
}
