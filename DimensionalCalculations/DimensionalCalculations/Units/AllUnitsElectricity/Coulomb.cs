namespace DimensionalCalculations.Units.AllUnitsElectricity
{
    public class Coulomb : AbstractUnit
    {
        public Coulomb()
        {
            Dimension = new DimensionVector()
            {
                Time = 1,
                Current = 1
            };
        }

        public override double FromSI(double value)
        {
            return value;
        }

        public override double ToSI(double value)
        {
            return value;
        }
    }
}
