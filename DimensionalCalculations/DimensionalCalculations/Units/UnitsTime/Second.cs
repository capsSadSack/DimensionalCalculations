using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.PhysicalDimensions.Units.UnitsTime
{
    public class Second : TimeUnit
    {
        public override string Name
        {
            get
            {
                return "s";
            }
        }

        public override double ToCGS(double value)
        {
            return value;
        }

        public override double ToSI(double value)
        {
            return value;
        }
    }
}
