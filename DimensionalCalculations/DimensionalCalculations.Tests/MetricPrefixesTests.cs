using NUnit.Framework;

using DimensionalCalculations.Units.UnitsLength;
using DimensionalCalculations.Units;

namespace DimensionalCalculations.Tests
{
    internal class MetricPrefixesTests
    {

        [TestCase(-1, 0.5)]
        [TestCase(-2, 0.05)]
        public void SubmultiplePrefix_CorrectValue(int powerOfTen, double expectedValue)
        {
            AbstractUnit dm = new MetricPrefixDecorator(new Meter(), powerOfTen);
            PhysicalQuantity pq = new PhysicalQuantity(5, dm);

            Assert.AreEqual(expectedValue, pq.Value, 1e-6);
        }

        [TestCase(3, 5e3)]
        [TestCase(6, 5e6)]
        public void MultiplePrefix_CorrectValue(int powerOfTen, double expectedValue)
        {
            AbstractUnit km = new MetricPrefixDecorator(new Meter(), powerOfTen);
            PhysicalQuantity pq = new PhysicalQuantity(5, km);

            Assert.AreEqual(expectedValue, pq.Value, 1e-3);
        }

        [Test]
        public void ZeroMultiplePrefix_SameValue()
        {
            AbstractUnit Mm = new MetricPrefixDecorator(new Meter(), 0);
            PhysicalQuantity pq = new PhysicalQuantity(5, Mm);

            Assert.AreEqual(5, pq.Value, 1e-3);
        }
    }
}
