namespace DimensionalCalculations.Units.UnitsArea
{ 
    public class Acre : AreaUnit
    {
        private const double _1_AC_EQUALS_m2 = 4046.8564224;

        public override double FromSI(double value)
        {
            return value / _1_AC_EQUALS_m2;
        }

        public override double ToSI(double value)
        {
            return value * _1_AC_EQUALS_m2;
        }
    }
}
