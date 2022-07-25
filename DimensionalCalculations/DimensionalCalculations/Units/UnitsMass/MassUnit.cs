using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.UnitsMass
{
    public abstract class MassUnit : AbstractUnit
    {
        protected MassUnit()
        {
            Dimension = new DimensionVector()
            {
                Mass = 1
            };
        }
    }
}
