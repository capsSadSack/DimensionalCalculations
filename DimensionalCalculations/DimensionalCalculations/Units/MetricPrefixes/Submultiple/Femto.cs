using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Femto : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e-15;


        public Femto(AbstractUnit instance) : base(instance)
        {
        }
    }
}
