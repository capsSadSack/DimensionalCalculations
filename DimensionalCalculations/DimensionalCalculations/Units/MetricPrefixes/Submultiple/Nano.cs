using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Nano : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e-9;


        public Nano(AbstractUnit instance) : base(instance)
        {
        }
    }
}
