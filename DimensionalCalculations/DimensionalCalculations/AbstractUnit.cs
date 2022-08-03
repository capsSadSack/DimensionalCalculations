using DimensionalCalculations;
using System.Collections.Generic;

namespace DimensionalCalculations
{
    public abstract class AbstractUnit
    {
        public virtual DimensionVector Dimension { get; set; }

        public abstract double ToSI(double value);

        public abstract double FromSI(double value);


        public static AbstractUnit operator *(AbstractUnit a, AbstractUnit b)
        {
            return new MultipliedUnit(a, b);
        }

        public static AbstractUnit operator /(AbstractUnit dividend, AbstractUnit divisor)
        {
            return new DividedUnit(dividend, divisor);
        }
    }

    public class MultipliedUnit : AbstractUnit
    {
        private AbstractUnit _firstUnit;
        private AbstractUnit _secondUnit;


        public MultipliedUnit(AbstractUnit a, AbstractUnit b)
        {
            _firstUnit = a;
            _secondUnit = b;

            Dimension = a.Dimension + b.Dimension;
        }
        

        public override double FromSI(double value)
        {
            return _secondUnit.FromSI(_firstUnit.FromSI(value));
        }

        public override double ToSI(double value)
        {
            return _secondUnit.ToSI(_firstUnit.ToSI(value));
        }
    }

    public class DividedUnit : AbstractUnit
    {
        private AbstractUnit _dividend;
        private AbstractUnit _divisor;


        public DividedUnit(AbstractUnit dividend, AbstractUnit divisor)
        {
            _dividend = dividend;
            _divisor = divisor;

            Dimension = dividend.Dimension - divisor.Dimension;
        }


        public override double FromSI(double value)
        {
            return _divisor.FromSI(1.0 / _dividend.FromSI(1.0 / value));
        }

        public override double ToSI(double value)
        {
            return _divisor.ToSI(1.0 / _dividend.ToSI(1.0 / value));
        }
    }
}
