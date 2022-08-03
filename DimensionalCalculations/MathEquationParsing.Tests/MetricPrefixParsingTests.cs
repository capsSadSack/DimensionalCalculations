using NUnit.Framework;

using MathEquationParsing.Exceptions;
using MathEquationParsing.Models;

namespace MathEquationParsing.Tests
{
    internal class MetricPrefixParsingTests
    {
        [TestCase("к")]
        [TestCase("k")]
        [TestCase("M")]
        [TestCase("m")]
        public void CorrectMetricPrefixStr_IsMetricPrefix_CorrectResult(string metricPrefixStr)
        {
            bool result = MetricPrefixParsing.IsMetricPrefix(metricPrefixStr);
            Assert.IsTrue(result);
        }

        [TestCase("mm")]
        [TestCase("kg")]
        [TestCase("i")]
        [TestCase("")]
        public void IncorrectMetricPrefixStr_IsMetricPrefix_NotMetricPrefix(string badMetricPrefixStr)
        {
            bool result = MetricPrefixParsing.IsMetricPrefix(badMetricPrefixStr);
            Assert.IsFalse(result);
        }

        [TestCase("к", MetricPrefix.Kilo)]
        [TestCase("k", MetricPrefix.Kilo)]
        [TestCase("M", MetricPrefix.Mega)]
        [TestCase("m", MetricPrefix.Milli)]
        public void CorrectMetricPrefix_GetMetricPrefix_CorrectResult(string metricPrefixStr, MetricPrefix expected)
        {
            var actual = MetricPrefixParsing.GetMetricPrefix(metricPrefixStr);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IncorrectMetricPrefix_GetMetricPrefix_Exception()
        {
            string badMetricPrefixStr = "fff";
            Assert.Throws<IncorrectMetricPrefixException>(() =>
            {
                MetricPrefixParsing.GetMetricPrefix(badMetricPrefixStr);
            });
        }
    }
}
