using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Tera : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e12;


        public Tera(AbstractUnit instance) : base(instance)
        {
        }
    }
}
