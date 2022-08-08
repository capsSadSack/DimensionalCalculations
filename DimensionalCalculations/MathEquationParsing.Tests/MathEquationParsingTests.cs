using NUnit.Framework;

using DimensionalCalculations;

namespace MathEquationParsing.Tests
{
    public class MathEquationParsingTests
    {
        #region Parsing Physical Quantity

        [Test]
        public void OnlyNumber_ParsePQ_CorrectParsing()
        {
            string str = "2";

            PhysicalQuantity? pq = MathEquationParsing.ParsePhysicalQuantity(str);

            Assert.AreEqual(2, pq.Value);
            Assert.IsTrue(pq.IsDimensionless());
        }

        [Test]
        public void OnlyNegativeNumber_ParsePQ_CorrectParsing()
        {
            string str = "-2";

            PhysicalQuantity? pq = MathEquationParsing.ParsePhysicalQuantity(str);

            Assert.AreEqual(-2, pq.Value);
            Assert.IsTrue(pq.IsDimensionless());
        }

        [Test]
        public void NumberWithUnit_ParsePQ_CorrectParsing()
        {
            string str = "2 kg";

            PhysicalQuantity? pq = MathEquationParsing.ParsePhysicalQuantity(str);

            Assert.AreEqual(2, pq.Value);
            Assert.AreEqual(1, pq.Dimension.Mass);
        }

        [Test]
        public void NegativeNumberWithUnit_ParsePQ_CorrectParsing()
        {
            string str = "-2 kg";

            PhysicalQuantity? pq = MathEquationParsing.ParsePhysicalQuantity(str);

            Assert.AreEqual(-2, pq.Value);
            Assert.AreEqual(1, pq.Dimension.Mass);
        }

        [Test]
        public void NumberWithComplexUnit_ParsePQ_CorrectParsing()
        {
            string str = "2 kg m";

            PhysicalQuantity? pq = MathEquationParsing.ParsePhysicalQuantity(str);

            Assert.AreEqual(2, pq.Value);
            Assert.AreEqual(1, pq.Dimension.Mass);
            Assert.AreEqual(1, pq.Dimension.Length);
        }

        #endregion
    }
}