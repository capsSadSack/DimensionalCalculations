namespace DimensionalCalculations.Units.UnitsForce
{
    internal class Dyne : ForceUnit
    {
        public override double FromSI(double value)
        {
            return 1e5 * value;
        }

        public override double ToSI(double value)
        {
            return value / 1e5;
        }
    }
}
