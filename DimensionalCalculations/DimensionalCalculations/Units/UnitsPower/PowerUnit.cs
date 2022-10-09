namespace DimensionalCalculations.Units.UnitsPower
{
    public abstract class PowerUnit : AbstractUnit
    {
        protected PowerUnit()
        {
            Dimension = new DimensionVector()
            {
                Mass = 1,
                Length = 2,
                Time = -3
            };
        }
    }
}
