using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Yocto : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e-24;


        public Yocto(AbstractUnit instance) : base(instance)
        {
        }
    }
}
