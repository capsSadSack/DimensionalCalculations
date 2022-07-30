using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Pico : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e-12;


        public Pico(AbstractUnit instance) : base(instance)
        {
        }
    }
}
