namespace DimensionalCalculations.Units
{
    public class DimensionlessUnit : AbstractUnit
    {
        public DimensionlessUnit()
        {
            Dimension = new DimensionVector();
        }

        public override double FromSI(double value)
        {
            return value;
        }

        public override double ToSI(double value)
        {
            return value;
        }
    }
}
