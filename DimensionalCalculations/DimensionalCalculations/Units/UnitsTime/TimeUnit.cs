using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.UnitsTime
{
    public abstract class TimeUnit : AbstractUnit
    {
        protected TimeUnit()
        {
            Dimension = new DimensionVector()
            {
                Time = 1
            };
        }
    }
}
