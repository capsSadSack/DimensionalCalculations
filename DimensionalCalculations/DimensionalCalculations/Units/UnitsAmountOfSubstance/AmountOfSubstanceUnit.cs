namespace DimensionalCalculations.Units.UnitsAmountOfSubstance
{
    public abstract class AmountOfSubstanceUnit : AbstractUnit
    {
        protected AmountOfSubstanceUnit()
        {
            Dimension = new DimensionVector()
            {
                AmountOfSubstance = 1
            };
        }
    }
}
