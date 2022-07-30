using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Exa : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e18;


        public Exa(AbstractUnit instance) : base(instance)
        {
        }
    }
}
