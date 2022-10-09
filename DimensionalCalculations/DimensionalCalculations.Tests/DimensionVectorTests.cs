using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DimensionalCalculations.Tests
{
    internal class DimensionVectorTests
    {
        [Test]
        public void NewDimensionVector_IsDimensionless()
        {
            DimensionVector dv = new DimensionVector();
            Assert.IsTrue(dv.IsDimensionless());
        }

        [Test]
        public void TwoDimensionVectors_Add_CorrectResult()
        {
            DimensionVector dv1 = new DimensionVector()
            {
                Length = 1
            };

            DimensionVector dv2 = new DimensionVector()
            {
                Mass = 2
            };

            DimensionVector result = dv1 + dv2;

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(2, result.Mass);
        }

        [Test]
        public void TwoSameDimensionVectors_Subtract_IsDimensionless()
        {
            DimensionVector dv1 = new DimensionVector()
            {
                Mass = 2
            };

            DimensionVector dv2 = new DimensionVector()
            {
                Mass = 2
            };

            DimensionVector result = dv1 - dv2;

            Assert.IsTrue(result.IsDimensionless());
        }

        [Test]
        public void TwoDimensionVectors_Subtract_CorrectResult()
        {
            DimensionVector dv1 = new DimensionVector()
            {
                Length = 1
            };

            DimensionVector dv2 = new DimensionVector()
            {
                Mass = 2
            };

            DimensionVector result = dv1 - dv2;

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(-2, result.Mass);
        }
    }
}
