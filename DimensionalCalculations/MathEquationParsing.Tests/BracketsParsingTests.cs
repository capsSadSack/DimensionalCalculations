using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MathEquationParsing.Tests
{
    internal class BracketsParsingTests
    {
        [TestCase("()")]
        [TestCase("()()()")]
        [TestCase("(())()")]
        [TestCase("((())())")]
        public void CorrectBrackets_CheckBrackets_Correct(string str)
        {
            Assert.IsTrue(BracketsParsing.CheckBrackets(str));
        }

        [TestCase("[]")]
        [TestCase("([])")]
        [TestCase("[(){}]")]
        public void CorrectDiffTypeBrackets_CheckBrackets_Correct(string str)
        {
            Assert.IsTrue(BracketsParsing.CheckBrackets(str));
        }

        [TestCase("())")]
        [TestCase(")(")]
        [TestCase("((")]
        [TestCase("((())")]
        public void IncorrectBrackets_CheckBrackets_Correct(string str)
        {
            Assert.IsFalse(BracketsParsing.CheckBrackets(str));
        }

        [TestCase("(]")]
        [TestCase("([]}")]
        [TestCase("[(])")]
        public void IncorrectDiffTypeBrackets_CheckBrackets_Correct(string str)
        {
            Assert.IsFalse(BracketsParsing.CheckBrackets(str));
        }
    }
}
