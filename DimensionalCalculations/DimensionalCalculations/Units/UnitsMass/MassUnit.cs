using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.PhysicalDimensions.Units.UnitsMass
{
    public class MassUnit : AbstractUnit
    {
        public override int[] DimArray => new int[] { 0, 1, 0, 0, 0, 0, 0 };

        public override string Name => "Mass unit";


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
