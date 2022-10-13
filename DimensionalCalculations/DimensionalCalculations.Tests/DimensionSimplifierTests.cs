using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DimensionalCalculations.DimensionOperations;
using NUnit.Framework;

namespace DimensionalCalculations.Tests
{
    internal class DimensionSimplifierTests
    {
        [TestCase("kg")]
        [TestCase("m")]
        [TestCase("A")]
        [TestCase("mol")]
        public void SingleSIUnits_SimplifyDimension_Correct(string unitStr)
        {
            PhysicalQuantity pq = new PhysicalQuantity(10, UnitsBase.GetAbstractUnit(unitStr));
            string str = DimensionSimplifier.ConvertToString(pq, SystemOfUnits.SystemInternational);
            Assert.AreEqual($"10 { unitStr }",  str);
        }

        [TestCase("km", "m")]
        [TestCase("kJ", "J")]
        public void SingleSIUnits_MetricPrefixes_SimplifyDimension_Correct_IsDimensionless(string unitStr, string expectedUnitStr)
        {
            PhysicalQuantity pq = new PhysicalQuantity(10, UnitsBase.GetAbstractUnit(unitStr));
            string str = DimensionSimplifier.ConvertToString(pq, SystemOfUnits.SystemInternational);
            Assert.AreEqual($"10000 {expectedUnitStr}", str);
        }

        [Test]
        public void ComplexUnit_SimplifyDimension_Correct_IsDimensionless()
        {
            PhysicalQuantity pq = new PhysicalQuantity(10, GetDimension(1, 1, -2, 0, 0, 0, 0));
            string str = DimensionSimplifier.ConvertToString(pq, SystemOfUnits.SystemInternational);
            Assert.AreEqual($"10 N", str);
        }

        [Test]
        public void SameUnitsDivision_SimplifyDimension_IsDimensionless()
        {
            PhysicalQuantity pq = new PhysicalQuantity(10, UnitsBase.GetAbstractUnit("kg"));
            PhysicalQuantity result = pq / pq;
            string str = DimensionSimplifier.ConvertToString(result, SystemOfUnits.SystemInternational);
            Assert.AreEqual($"1", str);
        }

        private static DimensionVector GetDimension(int length, int mass, int time, int current, int temperature, int amountOfSub, int lumIntensity)
        {
            return new DimensionVector()
            {
                AmountOfSubstance = amountOfSub,
                Current = current,
                Temperature = temperature,
                Time = time,
                Mass = mass,
                Length = length,
                LuminousIntensity = lumIntensity
            };
        }
    }
}
