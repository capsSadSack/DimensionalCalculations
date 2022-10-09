namespace DimensionalCalculations.Units.UnitsForce
{
    public abstract class ForceUnit : AbstractUnit
    {
        protected ForceUnit()
        {
            Dimension = new DimensionVector()
            {
                Mass = 1,
                Length = 1,
                Time = -2,
            };
        }
    }
}
