using NUnit.Framework;

using DimensionalCalculations;

namespace MathEquationParsing.Tests
{
    public class PhysicalQuantityParsingTests
    {
        #region Parsing Physical Quantity

        [Test]
        public void OnlyNumber_ParsePQ_CorrectParsing()
        {
            string str = "2";

            PhysicalQuantity? pq = PhysicalQuantityParsing.ParsePhysicalQuantity(str);

            Assert.AreEqual(2, pq.Value);
            Assert.IsTrue(pq.IsDimensionless());
        }

        [Test]
        public void OnlyNegativeNumber_ParsePQ_CorrectParsing()
        {
            string str = "-2";

            PhysicalQuantity? pq = PhysicalQuantityParsing.ParsePhysicalQuantity(str);

            Assert.AreEqual(-2, pq.Value);
            Assert.IsTrue(pq.IsDimensionless());
        }

        [Test]
        public void NumberWithUnit_ParsePQ_CorrectParsing()
        {
            string str = "2 kg";

            PhysicalQuantity? pq = PhysicalQuantityParsing.ParsePhysicalQuantity(str);

            Assert.AreEqual(2, pq.Value);
            Assert.AreEqual(1, pq.Dimension.Mass);
        }

        [Test]
        public void NegativeNumberWithUnit_ParsePQ_CorrectParsing()
        {
            string str = "-2 kg";

            PhysicalQuantity? pq = PhysicalQuantityParsing.ParsePhysicalQuantity(str);

            Assert.AreEqual(-2, pq.Value);
            Assert.AreEqual(1, pq.Dimension.Mass);
        }

        [Test]
        public void NumberWithComplexUnit_ParsePQ_CorrectParsing()
        {
            string str = "2 kg m";

            PhysicalQuantity? pq = PhysicalQuantityParsing.ParsePhysicalQuantity(str);

            Assert.AreEqual(2, pq.Value);
            Assert.AreEqual(1, pq.Dimension.Mass);
            Assert.AreEqual(1, pq.Dimension.Length);
        }

        #endregion

        #region IsSimpleUnit

        [TestCase("kg")]
        [TestCase("kg^2")]
        [TestCase("kg^(-2)")]
        [TestCase("1/kg")]
        public void CorrectSimpleUnit_IsSimpleUnit_True(string correctSimpleUnitStr)
        {
            Assert.IsTrue(PhysicalQuantityParsing.IsSimpleUnit(correctSimpleUnitStr));
        }

        [TestCase("1 kg")]
        [TestCase("kg^2 m")]
        [TestCase("kg^(-2) / 2")]
        [TestCase("kg^m")]
        public void IncorrectSimpleUnit_IsSimpleUnit_False(string incorrectSimpleUnitStr)
        {
            Assert.IsFalse(PhysicalQuantityParsing.IsSimpleUnit(incorrectSimpleUnitStr));
        }

        #endregion

        #region 

        [TestCase("kg")]
        [TestCase("kg^2")]
        [TestCase("kg^(-2)")]
        [TestCase("1/kg")]
        [TestCase("kg m")]
        [TestCase("kg^2 m^(-2)")]
        [TestCase("kg^(-2)/m")]
        [TestCase("kg^(-2)/m^(-3)")]
        public void CorrectUnit_IsUnit_True(string correctUnitStr)
        {
            Assert.IsTrue(PhysicalQuantityParsing.IsUnit(correctUnitStr));
        }

        [TestCase("1 kg")]
        [TestCase("kg^(-2) / 2")]
        [TestCase("kg^m")]
        [TestCase("7/kg")]
        public void IncorrectUnit_IsUnit_False(string incorrectUnitStr)
        {
            Assert.IsFalse(PhysicalQuantityParsing.IsUnit(incorrectUnitStr));
        }

        #endregion
    }
}