namespace DimensionalCalculations.Units.UnitsVolume
{
    public abstract class VolumeUnit : AbstractUnit
    {
        protected VolumeUnit()
        {
            Dimension = new DimensionVector()
            {
                Length = 3
            };
        }
    }
}
