using NUnit.Framework;

using DimensionalCalculations.Units.UnitsLength;
using DimensionalCalculations.Units;
using DimensionalCalculations.Exceptions;

namespace DimensionalCalculations.Tests
{
    internal class MetricPrefixesTests
    {
        [TestCase("к")]
        [TestCase("k")]
        [TestCase("M")]
        [TestCase("m")]
        public void CorrectMetricPrefixStr_IsMetricPrefix_CorrectResult(string metricPrefixStr)
        {
            bool result = MetricPrefixes.IsMetricPrefix(metricPrefixStr);
            Assert.IsTrue(result);
        }

        [TestCase("mm")]
        [TestCase("kg")]
        [TestCase("i")]
        [TestCase("")]
        public void IncorrectMetricPrefixStr_IsMetricPrefix_NotMetricPrefix(string badMetricPrefixStr)
        {
            bool result = MetricPrefixes.IsMetricPrefix(badMetricPrefixStr);
            Assert.IsFalse(result);
        }

        [TestCase("к", MetricPrefix.Kilo)]
        [TestCase("k", MetricPrefix.Kilo)]
        [TestCase("M", MetricPrefix.Mega)]
        [TestCase("m", MetricPrefix.Milli)]
        public void CorrectMetricPrefix_GetMetricPrefix_CorrectResult(string metricPrefixStr, MetricPrefix expected)
        {
            var actual = MetricPrefixes.GetMetricPrefix(metricPrefixStr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IncorrectMetricPrefix_GetMetricPrefix_Exception()
        {
            string badMetricPrefixStr = "fff";
            Assert.Throws<IncorrectMetricPrefixException>(() =>
            {
                MetricPrefixes.GetMetricPrefix(badMetricPrefixStr);
            });
        }


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
