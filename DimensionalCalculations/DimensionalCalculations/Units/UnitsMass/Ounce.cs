namespace DimensionalCalculations.Units.UnitsMass
{
    public class Ounce : MassUnit
    {
        private const double _1_OUNCE_IN_kg = 0.028349523125;

        public override double FromSI(double value)
        {
            return value / _1_OUNCE_IN_kg;
        }

        public override double ToSI(double value)
        {
            return _1_OUNCE_IN_kg * value;
        }
    }
}
