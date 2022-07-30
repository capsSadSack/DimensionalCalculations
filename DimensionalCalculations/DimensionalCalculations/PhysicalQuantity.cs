using DimensionalCalculations.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations
{
    public class PhysicalQuantity
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


        public PhysicalQuantity(double value_SI, DimensionVector dimension_SI)
        {
            Value = value_SI;
            Dimension = dimension_SI;
        }

        public PhysicalQuantity(double value, AbstractUnit unit)
        {
            _value_SI = unit.ToSI(value);
            Dimension = unit.Dimension;
        }


        public bool IsDimensionless()
        {
            return Dimension.IsDimensionless();
        }


        #region Operators

        public static PhysicalQuantity operator +(PhysicalQuantity quantity1, PhysicalQuantity quantity2)
        {
            if (quantity1.Dimension == quantity2.Dimension)
            {
                double value = quantity1.Value + quantity2.Value;
                return new PhysicalQuantity(value, quantity1.Dimension);
            }
            else
            {
                throw new PhysicalDimensionMustAgreeException();
            }
        }

        public static PhysicalQuantity operator -(PhysicalQuantity quantity1)
        {
            return new PhysicalQuantity(-quantity1.Value, quantity1.Dimension);
        }

        public static PhysicalQuantity operator -(PhysicalQuantity quantity1, PhysicalQuantity quantity2)
        {
            return quantity1 + (-quantity2);
        }

        public static PhysicalQuantity operator *(PhysicalQuantity quantity1, PhysicalQuantity quantity2)
        {
            double value = quantity1.Value * quantity2.Value;
            DimensionVector dimension = quantity1.Dimension + quantity2.Dimension;

            return new PhysicalQuantity(value, dimension);
        }

        public static PhysicalQuantity operator *(PhysicalQuantity quantity, double number)
        {
            double value = quantity.Value * number;
            return new PhysicalQuantity(value, quantity.Dimension);
        }

        public static PhysicalQuantity operator *(double number, PhysicalQuantity quantity)
        {
            return quantity * number; ;
        }

        public static PhysicalQuantity operator /(PhysicalQuantity quantity1, PhysicalQuantity quantity2)
        {
            double value = quantity1.Value / quantity2.Value;
            DimensionVector dimension = quantity1.Dimension - quantity2.Dimension;

            return new PhysicalQuantity(value, dimension);
        }

        public static PhysicalQuantity operator /(PhysicalQuantity quantity, double number)
        {
            double value = quantity.Value / number;
            return new PhysicalQuantity(value, quantity.Dimension);
        }

        #endregion 
    }
}
