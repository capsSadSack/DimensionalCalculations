using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Atto : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e-18;


        public Atto(AbstractUnit instance) : base(instance)
        {
        }
    }
}
