using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.UnitsLength
{
    public abstract class LengthUnit : AbstractUnit
    {
        protected LengthUnit()
        {
            Dimension = new DimensionVector()
            {
                Length = 1
            };
        }
    }
}
