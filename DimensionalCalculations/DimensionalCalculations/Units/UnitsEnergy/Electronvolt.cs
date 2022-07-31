using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.UnitsEnergy
{
    public class Electronvolt : EnergyUnit
    {
        private const double _JOULES_IN_1eV = 1.602176634e-19;

        public override double FromSI(double value)
        {
            return value / _JOULES_IN_1eV;
        }

        public override double ToSI(double value)
        {
            return value * _JOULES_IN_1eV;
        }
    }
}
