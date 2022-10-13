namespace DimensionalCalculations.Units.UnitsLength
{
    public abstract class LengthUnit : AbstractUnit
    {
        protected LengthUnit()
        {
            Dimension = new DimensionVector()
            {
                Length = 1
            };
        }
    }
}
