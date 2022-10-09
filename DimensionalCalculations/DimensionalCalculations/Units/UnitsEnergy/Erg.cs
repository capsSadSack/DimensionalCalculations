namespace DimensionalCalculations.Units.UnitsEnergy
{
    public class Erg : EnergyUnit
    {
        private const double _JOULES_IN_1ERG = 1e-7;

        public override double FromSI(double value)
        {
            return value / _JOULES_IN_1ERG;
        }

        public override double ToSI(double value)
        {
            return value * _JOULES_IN_1ERG;
        }
    }
}
