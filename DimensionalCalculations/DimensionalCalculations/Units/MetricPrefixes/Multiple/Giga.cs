using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Giga : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e9;


        public Giga(AbstractUnit instance) : base(instance)
        {
        }
    }
}
