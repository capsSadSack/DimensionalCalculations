namespace DimensionalCalculations.Units.UnitsMass
{
    public abstract class MassUnit : AbstractUnit
    {
        protected MassUnit()
        {
            Dimension = new DimensionVector()
            {
                Mass = 1
            };
        }
    }
}
