using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units
{
    public abstract class AbstractUnitDecorator : AbstractUnit
    {
        protected AbstractUnit _instance;

        public override DimensionVector Dimension
        {
            get
            {
                return _instance.Dimension;
            }
            set
            {
                _instance.Dimension = value;
            }
        }

        public AbstractUnitDecorator(AbstractUnit instance)
        {
            _instance = instance;
        }

        public override double FromSI(double value) => _instance.FromSI(value);
        public override double ToSI(double value) => _instance.ToSI(value);
    }
}
