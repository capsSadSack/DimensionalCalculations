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

        [TestCase("((text))")]
        [TestCase("[(text)]")]
        [TestCase("[{(text)}]")]
        public void NestedBrackets_RemoveUselessBrackets_Correct(string str)
        {
            string formattedStr = BracketsParsing.RemoveUselessBrackets(str);
            Assert.AreEqual("(text)", formattedStr);
        }

        [TestCase("()()()")]
        [TestCase("[](){}")]
        [TestCase("()text()")]
        public void NoNestedBrackets_NoNestedBrackets_Correct(string str)
        {
            Assert.IsTrue(BracketsParsing.NoNestedBrackets(str));
        }

        [TestCase("(())")]
        [TestCase("([])")]
        [TestCase("(){()}")]
        public void NestedBrackets_NoNestedBrackets_Correct(string str)
        {
            Assert.IsFalse(BracketsParsing.NoNestedBrackets(str));
        }
    }
}
