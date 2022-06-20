using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.PhysicalDimensions.Units.UnitsLength
{
    public class Mile : LengthUnit
    {
        public override string Name
        {
            get
            {
                return "mi";
            }
        }

        public override double ToCGS(double value)
        {
            return value * 160934.4;
        }

        public override double ToSI(double value)
        {
            return value * 1609.344;
        }
    }
}
