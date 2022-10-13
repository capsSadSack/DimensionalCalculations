namespace DimensionalCalculations.Units.UnitsPressure
{
    public abstract class PressureUnit : AbstractUnit
    {
        protected PressureUnit()
        {
            Dimension = new DimensionVector()
            {
                Mass = 1,
                Length = -1,
                Time = -2
            };
        }
    }
}
