namespace DimensionalCalculations.Units.UnitsPower
{
    public class Horsepower : PowerUnit
    {
        private const double _1_HP_IN_W = 735.49875;

        public override double FromSI(double value)
        {
            return value / _1_HP_IN_W;
        }

        public override double ToSI(double value)
        {
            return _1_HP_IN_W * value;
        }
    }
}
