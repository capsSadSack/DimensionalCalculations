namespace DimensionalCalculations.Units.UnitsArea
{
    public class Are : AreaUnit
    {
        private const double _1_ARE_EQUALS_m2 = 100;

        public override double FromSI(double value)
        {
            return value / _1_ARE_EQUALS_m2;
        }

        public override double ToSI(double value)
        {
            return value * _1_ARE_EQUALS_m2;
        }
    }
}
