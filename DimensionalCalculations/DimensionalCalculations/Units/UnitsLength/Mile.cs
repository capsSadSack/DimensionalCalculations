using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.UnitsLength
{
    public class Mile : LengthUnit
    {
        public override double FromSI(double value)
        {
            return value / 1609.344;
        }

        public override double ToSI(double value)
        {
            return value * 1609.344;
        }
    }
}
