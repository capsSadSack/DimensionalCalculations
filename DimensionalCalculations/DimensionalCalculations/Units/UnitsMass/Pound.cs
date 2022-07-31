namespace DimensionalCalculations.Units.UnitsMass
{
    public class Pound : MassUnit
    {
        private const double _1_POUND_IN_kg = 0.45359237;

        public override double FromSI(double value)
        {
            return value / _1_POUND_IN_kg;
        }

        public override double ToSI(double value)
        {
            return _1_POUND_IN_kg * value;
        }
    }
}
