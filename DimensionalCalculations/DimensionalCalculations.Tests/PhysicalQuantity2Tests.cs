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

        [Test]
        public void TwoPhysicalQuantities_Multiply_CorrectValueAndDimension()
        {
            PhysicalQuantity2 pq1 = new PhysicalQuantity2(15, new Meter());
            PhysicalQuantity2 pq2 = new PhysicalQuantity2(5, new Meter());
            PhysicalQuantity2 pq = pq1 * pq2;

            Assert.AreEqual(75, pq.Value);
            Assert.AreEqual(2, pq.Dimension.Length);
        }

        [Test]
        public void PhysicalQuantity_MultiplyByNumber_CorrectValueAndDimension()
        {
            PhysicalQuantity2 pq = new PhysicalQuantity2(15, new Meter());
            PhysicalQuantity2 pq1 = pq * 15;
            PhysicalQuantity2 pq2 = 5 * pq;

            Assert.AreEqual(225, pq1.Value);
            Assert.AreEqual(1, pq1.Dimension.Length);

            Assert.AreEqual(75, pq2.Value);
            Assert.AreEqual(1, pq2.Dimension.Length);
        }

        [Test]
        public void TwoPhysicalQuantities_Divide_CorrectValueAndDimension()
        {
            PhysicalQuantity2 pq1 = new PhysicalQuantity2(15, new Meter());
            PhysicalQuantity2 pq2 = new PhysicalQuantity2(5, new Meter());
            PhysicalQuantity2 pq = pq1 * pq2;

            Assert.AreEqual(75, pq.Value);
            Assert.AreEqual(2, pq.Dimension.Length);
        }

        [Test]
        public void SameDimensionQuantities_Divide_NoDimension()
        {
            PhysicalQuantity2 pq1 = new PhysicalQuantity2(15, new Meter());
            PhysicalQuantity2 pq2 = new PhysicalQuantity2(5, new Meter());
            PhysicalQuantity2 pq = pq1 / pq2;

            Assert.AreEqual(3, pq.Value);
            Assert.IsTrue(pq.IsDimensionless());
        }

        [Test]
        public void PhysicalQuantity_DivideByNumber_CorrectValueAndDimension()
        {
            PhysicalQuantity2 pq = new PhysicalQuantity2(15, new Meter());
            PhysicalQuantity2 pq1 = pq / 5;

            Assert.AreEqual(3, pq1.Value);
            Assert.AreEqual(1, pq1.Dimension.Length);
        }
    }
}