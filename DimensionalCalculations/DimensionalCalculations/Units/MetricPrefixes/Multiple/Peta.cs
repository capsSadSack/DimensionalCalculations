using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Peta : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e15;


        public Peta(AbstractUnit instance) : base(instance)
        {
        }
    }
}
