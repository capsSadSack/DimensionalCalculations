namespace DimensionalCalculations.Units.UnitsTemperature
{
    public abstract class TemperatureUnit : AbstractUnit
    {
        protected TemperatureUnit()
        {
            Dimension = new DimensionVector()
            {
                Temperature = 1
            };
        }
    }
}
