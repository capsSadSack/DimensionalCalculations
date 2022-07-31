namespace DimensionalCalculations.Units.UnitsEnergy
{
    public abstract class EnergyUnit : AbstractUnit
    {
        protected EnergyUnit()
        {
            Dimension = new DimensionVector()
            {
                Mass = 1,
                Length = 2,
                Time = -2
            };
        }
    }
}
