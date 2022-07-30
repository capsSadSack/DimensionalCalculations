using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionalCalculations.Units.MetricPrefixes
{
    public class Deca : MultiplicationPrefix
    {
        protected override double MultiplicationNumber => 10;


        public Deca(AbstractUnit instance) : base(instance)
        {
        }
    }
}
