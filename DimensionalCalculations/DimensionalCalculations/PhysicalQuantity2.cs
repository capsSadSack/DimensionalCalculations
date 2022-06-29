using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations
{
    internal class PhysicalQuantity2
    {
        private double _value_SI;

        public double Value 
        { 
            get
            {
                return _value_SI;
            }
            private set
            {
                _value_SI = value;
            }
        }

        public DimensionVector Dimension;


        public PhysicalQuantity2()
        {

        }
    }
}
