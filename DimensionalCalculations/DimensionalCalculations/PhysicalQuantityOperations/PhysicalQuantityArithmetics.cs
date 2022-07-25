using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.PhysicalQuantityOperations
{
    internal class PhysicalQuantityArithmetics
    {
        public static PhysicalQuantity DoAddition(PhysicalQuantity physQuantity1, PhysicalQuantity physQuantity2)
        {
            if (PhysicalQuantityChecking.HaveSameDimension(physQuantity1, physQuantity2))
            {
                // UNDONE:
                throw new NotImplementedException();
            }
            else
            {
                // UNDONE: PhysicalUnitsMustAgreeException
                throw new NotImplementedException();
            }
        }
    }
}
