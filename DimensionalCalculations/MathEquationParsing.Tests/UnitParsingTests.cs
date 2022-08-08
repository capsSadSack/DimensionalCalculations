﻿using NUnit.Framework;

using MathEquationParsing.Exceptions;
using DimensionalCalculations;

namespace MathEquationParsing.Tests
{
    internal class UnitParsingTests
    {
        // Will fail with this str: "((kg mol) (mol))/(m s)";

        [TestCase("Kg")]
        [TestCase("kg + s")]
        public void IncorrectUnit_GetUnit_Exception(string incorrectUnitSrt)
        {
            Assert.Throws<IncorrectUnitException>(() =>
            {
                UnitParsing.GetUnit(incorrectUnitSrt);
            });
        }

        [Test]
        public void EmptyString_GetUnit_DimensionlessUnit()
        {
            string incorrectUnitSrt = "";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.IsTrue(result.Dimension.IsDimensionless());
        }

        [Test]
        public void SimpleUnitStr_GetUnit_CorrectDimension()
        {
            string incorrectUnitSrt = "kg";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.AreEqual(1, result.Dimension.Mass);
        }

        [Test]
        public void MultipliedUnitStr_GetUnit_CorrectDimension()
        {
            string incorrectUnitSrt = "kg s";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.AreEqual(1, result.Dimension.Mass);
            Assert.AreEqual(1, result.Dimension.Time);
        }

        [Test]
        public void DividedUnitStr_GetUnit_CorrectDimension()
        {
            string incorrectUnitSrt = "kg/s";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.AreEqual(1, result.Dimension.Mass);
            Assert.AreEqual(-1, result.Dimension.Time);
        }

        [Test]
        public void DividedMultiplicatedUnitStr_GetUnit_CorrectDimension()
        {
            string incorrectUnitSrt = "kg m/s";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.AreEqual(1, result.Dimension.Mass);
            Assert.AreEqual(1, result.Dimension.Length);
            Assert.AreEqual(-1, result.Dimension.Time);
        }

        [Test]
        public void TwiceDividedUnitStr_GetUnit_CorrectDimension()
        {
            string incorrectUnitSrt = "kg/s/s";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.AreEqual(1, result.Dimension.Mass);
            Assert.AreEqual(-2, result.Dimension.Time);
        }

        [Test]
        public void MultiplicationOfTwoDividedUnitsStr_GetUnit_CorrectDimension()
        {
            string incorrectUnitSrt = "kg/s m/s";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.AreEqual(1, result.Dimension.Mass);
            Assert.AreEqual(1, result.Dimension.Length);
            Assert.AreEqual(-2, result.Dimension.Time);
        }

        [Test]
        public void BracketDividedUnitStr_GetUnit_CorrectDimension()
        {
            string incorrectUnitSrt = "kg/(m s)";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.AreEqual(1, result.Dimension.Mass);
            Assert.AreEqual(-1, result.Dimension.Time);
            Assert.AreEqual(-1, result.Dimension.Length);
        }

        [Test]
        public void BracketDividedUnitTwiceStr_GetUnit_CorrectDimension()
        {
            string incorrectUnitSrt = "kg/(m s)/m^2";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.AreEqual(1, result.Dimension.Mass);
            Assert.AreEqual(-1, result.Dimension.Time);
            Assert.AreEqual(-3, result.Dimension.Length);
        }

        [Test]
        public void BothDividendAndDivisorAreInBracketStr_GetUnit_CorrectDimension()
        {
            string incorrectUnitSrt = "(kg mol)/(m s)";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.AreEqual(1, result.Dimension.Mass);
            Assert.AreEqual(1, result.Dimension.AmountOfSubstance);
            Assert.AreEqual(-1, result.Dimension.Time);
            Assert.AreEqual(-1, result.Dimension.Length);
        }

        [Test]
        public void UselessBracketStr_GetUnit_CorrectDimension()
        {
            string incorrectUnitSrt = "((kg mol) (mol))/(m s)";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.AreEqual(1, result.Dimension.Mass);
            Assert.AreEqual(2, result.Dimension.AmountOfSubstance);
            Assert.AreEqual(-1, result.Dimension.Time);
            Assert.AreEqual(-1, result.Dimension.Length);
        }

        [Test]
        public void PowerUnitStr_GetUnit_CorrectDimension()
        {
            string incorrectUnitSrt = "kg^2";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.AreEqual(2, result.Dimension.Mass);
        }

        [Test]
        public void DividedByPowerUnitStr_GetUnit_CorrectDimension()
        {
            string incorrectUnitSrt = "m / s^2";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.AreEqual(1, result.Dimension.Length);
            Assert.AreEqual(-2, result.Dimension.Time);
        }

        [Test]
        public void OneInUnitStr_GetUnit_CorrectDimension()
        {
            string incorrectUnitSrt = "1 / s^2";
            AbstractUnit result = UnitParsing.GetUnit(incorrectUnitSrt);

            Assert.AreEqual(-2, result.Dimension.Time);
        }
    }
}