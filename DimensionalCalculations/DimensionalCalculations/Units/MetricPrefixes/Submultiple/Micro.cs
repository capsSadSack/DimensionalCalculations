using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Micro : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 1e-6;


        public Micro(AbstractUnit instance) : base(instance)
        {
        }
    }
}
