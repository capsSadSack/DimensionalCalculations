namespace DimensionalCalculations.Units.UnitsCurrent
{
    public abstract class CurrentUnit : AbstractUnit
    {
        protected CurrentUnit()
        {
            Dimension = new DimensionVector()
            {
                Current = 1
            };
        }
    }
}
