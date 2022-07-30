using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Milli : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e-3;


        public Milli(AbstractUnit instance) : base(instance)
        {
        }
    }
}
