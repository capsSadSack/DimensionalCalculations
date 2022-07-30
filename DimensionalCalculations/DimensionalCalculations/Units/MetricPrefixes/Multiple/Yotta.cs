using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Yotta : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e24;


        public Yotta(AbstractUnit instance) : base(instance)
        {
        }
    }
}
