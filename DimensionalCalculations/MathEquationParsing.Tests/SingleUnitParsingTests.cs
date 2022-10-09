using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEquationParsing.Tests
{
    internal class SingleUnitParsingTests
    {
        [TestCase("m")]
        [TestCase("km")]
        [TestCase("mi")]
        public void SimpleUnit_ParseSingleUnit_CorrectParsing(string unitStr)
        {
            var unit = SingleUnitParsing.ParseSingleUnit(unitStr);
            Assert.AreEqual(1, unit.Dimension.Length);
        }
    }
}
