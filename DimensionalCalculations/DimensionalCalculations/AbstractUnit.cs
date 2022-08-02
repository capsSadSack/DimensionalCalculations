using DimensionalCalculations;
using System.Collections.Generic;

namespace DimensionalCalculations
{
    public abstract class AbstractUnit
    {
        public virtual DimensionVector Dimension { get; set; }

        public abstract double ToSI(double value);

        public abstract double FromSI(double value);
    }
}
