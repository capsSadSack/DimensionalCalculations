namespace DimensionalCalculations.Units.AllUnitsElectricity
{
    public class Volt : AbstractUnit
    {
        public Volt()
        {
            Dimension = new DimensionVector()
            {
                Mass = 1,
                Length = 2,
                Time = -3,
                Current = -1
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
