namespace DimensionalCalculations.Units.UnitsLength
{
    public class AstronomicalUnit : LengthUnit
    {
        private const double _1_AU_EQUALS_m = 1.495978707E11;

        public override double FromSI(double value)
        {
            return value / _1_AU_EQUALS_m;
        }

        public override double ToSI(double value)
        {
            return value * _1_AU_EQUALS_m;
        }
    }
}
