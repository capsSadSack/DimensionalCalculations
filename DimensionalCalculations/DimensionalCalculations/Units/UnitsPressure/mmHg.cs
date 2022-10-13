namespace DimensionalCalculations.Units.UnitsPressure
{
    // 
    public class mmHg : PressureUnit
    {
        private const double _1_mmHGgIN_Pa = 133.3223684;

        public override double FromSI(double value)
        {
            return value / _1_mmHGgIN_Pa;
        }

        public override double ToSI(double value)
        {
            return _1_mmHGgIN_Pa * value;
        }
    }
}
