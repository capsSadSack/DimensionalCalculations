using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.PhysicalDimensions.Units.UnitsTime
{
    public abstract class TimeUnit : AbstractUnit
    {
        public override int[] DimArray
        {
            get { return new int[] { 0, 0, 1, 0, 0, 0, 0, }; }
        }

        public override string Name => "Time unit";

        public override double ToCGS(double value)
        {
            throw new NotImplementedException();
        }

        public override double ToSI(double value)
        {
            throw new NotImplementedException();
        }
    }
}
