namespace DimensionalCalculations.Units.AllUnitsElectricity
{
    public class Farad : AbstractUnit
    {
        public Farad()
        {
            Dimension = new DimensionVector()
            {
                Mass = -1,
                Length = -2,
                Time = 4,
                Current = 2
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
