using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Zetta : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e21;


        public Zetta(AbstractUnit instance) : base(instance)
        {
        }
    }
}
