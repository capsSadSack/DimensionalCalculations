using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using DimensionalCalculations.Units.MetricPrefixes;
using DimensionalCalculations.Units.UnitsLength;

namespace DimensionalCalculations.Tests
{
    internal class MetricPrefixesTests
    {
        [Test]
        public void Test()
        {
            AbstractUnit km = new Kilo(new Meter());
            PhysicalQuantity2 pq = new PhysicalQuantity2(10, km);

            Assert.AreEqual(10000, pq.Value);
        }
    }
}
