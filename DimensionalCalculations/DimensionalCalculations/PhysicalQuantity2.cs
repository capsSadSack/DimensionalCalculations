﻿using DimensionalCalculations.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations
{
    public class PhysicalQuantity2
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


        public PhysicalQuantity2(double value_SI, DimensionVector dimension_SI)
        {
            Value = value_SI;
            Dimension = dimension_SI;
        }

        public PhysicalQuantity2(double value, AbstractUnit unit)
        {
            _value_SI = unit.ToSI(value);
            Dimension = unit.Dimension;
        }


        #region Operators

        public static PhysicalQuantity2 operator +(PhysicalQuantity2 quantity1, PhysicalQuantity2 quantity2)
        {
            if (quantity1.Dimension == quantity2.Dimension)
            {
                double value = quantity1.Value + quantity2.Value;
                return new PhysicalQuantity2(value, quantity1.Dimension);
            }
            else
            {
                throw new PhysicalDimensionMustAgreeException();
            }
        }

        public static PhysicalQuantity2 operator -(PhysicalQuantity2 quantity1)
        {
            return new PhysicalQuantity2(-quantity1.Value, quantity1.Dimension);
        }

        public static PhysicalQuantity2 operator -(PhysicalQuantity2 quantity1, PhysicalQuantity2 quantity2)
        {
            return quantity1 + (-quantity2);
        }

        #endregion 
    }
}
