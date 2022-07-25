using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    internal abstract class MultiplicationPrefix : AbstractUnitDecorator
    {
        protected abstract int MultiplicationNumber { get; }

        public MultiplicationPrefix(AbstractUnit instance) : base(instance)
        {
        }

        public override double FromSI(double value)
        {
            return base.FromSI(value) / MultiplicationNumber;
        }

        public override double ToSI(double value)
        {
            return MultiplicationNumber * base.ToSI(value);
        }
    }
}
