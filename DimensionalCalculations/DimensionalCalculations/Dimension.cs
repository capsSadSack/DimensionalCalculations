using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.PhysicalDimensions
{
    public struct Dimension
    {
        public DimensionName Unit;
        public int Power;

        public Dimension(DimensionName unit, int power)
        {
            this.Unit = unit;
            this.Power = power;
        }
    }
}
