using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Zepto : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e-21;


        public Zepto(AbstractUnit instance) : base(instance)
        {
        }
    }
}
