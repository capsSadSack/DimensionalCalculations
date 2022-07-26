using NUnit.Framework;

using DimensionalCalculations.Units.UnitsLength;

namespace DimensionalCalculations.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NewPhysicalQuantity_Constructor_CorrectValueAndDimension()
        {
            PhysicalQuantity2 pq = new PhysicalQuantity2(15, new Meter());

            Assert.AreEqual(15, pq.Value);
            Assert.AreEqual(1, pq.Dimension.Length);
        }

        [Test]
        public void TwoPhysicalQuantities_Add_CorrectValueAndDimension()
        {
            PhysicalQuantity2 pq1 = new PhysicalQuantity2(15, new Meter());
            PhysicalQuantity2 pq2 = new PhysicalQuantity2(5, new Meter());

            PhysicalQuantity2 pq = pq1 + pq2;

            Assert.AreEqual(20, pq.Value);
            Assert.AreEqual(1, pq.Dimension.Length);
        }

        [Test]
        public void TwoPhysicalQuantities_Substract_CorrectValueAndDimension()
        {
            PhysicalQuantity2 pq1 = new PhysicalQuantity2(15, new Meter());
            PhysicalQuantity2 pq2 = new PhysicalQuantity2(5, new Meter());

            PhysicalQuantity2 pq = pq1 - pq2;

            Assert.AreEqual(10, pq.Value);
            Assert.AreEqual(1, pq.Dimension.Length);
        }

        [Test]
        public void TwoPhysicalQuantities_Negation_CorrectValueAndDimension()
        {
            PhysicalQuantity2 pq1 = new PhysicalQuantity2(15, new Meter());
            PhysicalQuantity2 pq = -pq1;

            Assert.AreEqual(-15, pq.Value);
            Assert.AreEqual(1, pq.Dimension.Length);
        }
    }
}