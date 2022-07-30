using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Centi : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e-2;


        public Centi(AbstractUnit instance) : base(instance)
        {
        }
    }
}
