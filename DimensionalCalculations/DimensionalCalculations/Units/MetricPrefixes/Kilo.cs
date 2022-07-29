using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Kilo : MultiplicationPrefix
    {
        protected override int MultiplicationNumber => 1_000;


        public Kilo(AbstractUnit instance) : base(instance)
        {
        }
    }
}
