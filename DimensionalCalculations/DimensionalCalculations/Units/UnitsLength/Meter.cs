using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.PhysicalDimensions.Units.UnitsLength
{
    public class Meter : LengthUnit
    {
        public override string Name
        {
            get
            {
                return "m";
            }
        }

        public override double ToCGS(double value)
        {
            return value / 100.0;
        }

        public override double ToSI(double value)
        {
            return value;
        }
    }
}
