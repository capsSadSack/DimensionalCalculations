using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.UnitsLength
{
    public class Meter : LengthUnit
    {

        public override double FromSI(double value)
        {
            return value;
        }

        public override double ToSI(double value)
        {
            return value;
        }
    }
}
