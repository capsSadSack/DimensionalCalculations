namespace DimensionalCalculations.Units.UnitsMass
{
    public class Gram : MassUnit
    {
        public override double FromSI(double value)
        {
            return 1000.0 * value;
        }

        public override double ToSI(double value)
        {
            return value / 1000.0;
        }
    }
}
