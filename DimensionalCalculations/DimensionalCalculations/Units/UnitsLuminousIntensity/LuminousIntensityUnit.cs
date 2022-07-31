namespace DimensionalCalculations.Units.UnitsLuminousIntensity
{
    public abstract class LuminousIntensityUnit : AbstractUnit
    {
        protected LuminousIntensityUnit()
        {
            Dimension = new DimensionVector()
            {
                LuminousIntensity = 1
            };
        }
    }
}
