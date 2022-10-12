namespace DimensionalCalculations.Units.UnitsMass
{
    public class Tonne : MassUnit
    {
        private const double _1_TONNE_IN_kg = 1000;

        public override double FromSI(double value)
        {
            return value / _1_TONNE_IN_kg;
        }

        public override double ToSI(double value)
        {
            return _1_TONNE_IN_kg * value;
        }
    }
}
