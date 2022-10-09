namespace DimensionalCalculations.Units.UnitsTime
{
    public abstract class TimeUnit : AbstractUnit
    {
        protected TimeUnit()
        {
            Dimension = new DimensionVector()
            {
                Time = 1
            };
        }
    }
}
