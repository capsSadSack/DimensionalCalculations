namespace DimensionalCalculations.Units.UnitsMass
{
    public class Carat : MassUnit
    {
        private const double _1_CARAT_IN_kg = 0.0002;

        public override double FromSI(double value)
        {
            return value / _1_CARAT_IN_kg;
        }

        public override double ToSI(double value)
        {
            return _1_CARAT_IN_kg * value;
        }
    }
}
