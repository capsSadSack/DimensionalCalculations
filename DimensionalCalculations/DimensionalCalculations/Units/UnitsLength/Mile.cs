namespace DimensionalCalculations.Units.UnitsLength
{
    public class Mile : LengthUnit
    {
        private const double _1_MILE_EQUALS_m = 1609.344;

        public override double FromSI(double value)
        {
            return value / _1_MILE_EQUALS_m;
        }

        public override double ToSI(double value)
        {
            return value * _1_MILE_EQUALS_m;
        }
    }
}
