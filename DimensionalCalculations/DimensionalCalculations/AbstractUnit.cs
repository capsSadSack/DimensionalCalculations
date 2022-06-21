using DimensionalCalculations;
using System.Collections.Generic;

namespace Physics.PhysicalDimensions
{
    public abstract class AbstractUnit
    {
        public DimensionVector Dimension { get; protected set; }



        public abstract double ToSI(double value);

        public abstract double FromSI(double value);
    }
}
