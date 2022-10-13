namespace DimensionalCalculations.Units.AllUnitsElectricity
{
    public class Ohm : AbstractUnit
    {
        public Ohm()
        {
            Dimension = new DimensionVector()
            {
                Mass = 1,
                Length = 2,
                Time = -3,
                Current = -2
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
