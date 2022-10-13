namespace DimensionalCalculations.Units.UnitsArea
{
    public abstract class AreaUnit : AbstractUnit
    {
        protected AreaUnit()
        {
            Dimension = new DimensionVector()
            {
                Length = 2
            };
        }
    }
}
