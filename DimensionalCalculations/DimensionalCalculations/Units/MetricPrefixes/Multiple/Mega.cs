using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Mega : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1_000_000;


        public Mega(AbstractUnit instance) : base(instance)
        {
        }
    }
}
