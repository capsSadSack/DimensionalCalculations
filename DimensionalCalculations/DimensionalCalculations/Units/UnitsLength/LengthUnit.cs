using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.PhysicalDimensions.Units.UnitsLength
{
    public class LengthUnit : AbstractUnit
    {
        public override int[] DimArray
        {
            get { return new int[] { 1, 0, 0, 0, 0, 0, 0, }; }
        }

        public override string Name => "Length unit";

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
