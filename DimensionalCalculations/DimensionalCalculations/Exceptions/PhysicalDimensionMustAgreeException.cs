using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Exceptions
{
    public class PhysicalDimensionMustAgreeException : Exception
    {
        public PhysicalDimensionMustAgreeException() : base()
        {

        }

        public PhysicalDimensionMustAgreeException(string message) : base(message)
        {

        }
    }
}
