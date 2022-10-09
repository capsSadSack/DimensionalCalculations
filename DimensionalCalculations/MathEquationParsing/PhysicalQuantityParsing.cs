using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DimensionalCalculations;
using MathEquationParsing.Exceptions;

namespace MathEquationParsing
{
    public static class PhysicalQuantityParsing
    {
        public static PhysicalQuantity ParsePhysicalQuantity(string str)
        { 
            SplitNumberAndUnit(str, out string numberStr, out string unitStr);

            double value = Convert.ToDouble(numberStr);
            AbstractUnit unit = UnitParsing.GetUnit(unitStr);
            return new PhysicalQuantity(value, unit);
        }

        private static void SplitNumberAndUnit(string str, out string numberStr, out string unitStr)
        {
            numberStr = "";
            unitStr = "";

            string[] parts = SplitAfterNumber(str)
                .Where(x => x.Length > 0)
                .ToArray();

            bool signExpected = true;
            bool numberExpected = true;
            bool unitExpected = false;

            for (int i = 0; i < parts.Count(); i++)
            {
                if (IsSign(parts[i]) && signExpected)
                {
                    numberStr += parts[i];
                    signExpected = false;
                }
                else if (IsNumber(parts[i]) && numberExpected)
                {
                    numberStr += parts[i];
                    signExpected = false;
                    numberExpected = false;
                    unitExpected = true;
                }
                else if (IsUnit(parts[i]) && unitExpected)
                {
                    unitStr += parts[i] + " ";
                }
                else
                {
                    throw new PhysicalQuantityParsingException();
                }
            }
        }

        private static IEnumerable<string> SplitAfterNumber(string str)
        {
            if (str.Length == 0)
            {
                throw new ArgumentException("Wrong string format. String must contain symbols to be parsed.");
            }
            else if (str.Length > 0 && !IsNumber(str.First()) && !IsSign(str.First()))
            {
                throw new ArgumentException("Wrong string format. String must be started with number.");
            }

            string numberStr = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                char currCh = str[i];

                if (IsNumber(currCh) || IsSign(currCh))
                {
                    numberStr += currCh;
                }
                else
                {
                    break;
                }
            }

            return new List<string> { numberStr, str.Substring(numberStr.Length) };
        }

        private static bool IsSign(char ch)
        {
            return ch == '-' || ch == '+';
        }

        private static bool IsNumber(char ch)
        {
            return ch >= '0' && ch <= '9';
        }


        #region Checkings

        private static bool IsNumber(string str)
        {
            if (str.Count() == 0)
            {
                return false;
            }

            string mayBeNumbersStr = str;

            if (str[0] == '-')
            {
                mayBeNumbersStr = str.Substring(1);
            }

            foreach (char ch in mayBeNumbersStr)
            {
                if (!IsFigure(ch))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsFigure(char ch)
        {
            return ch >= '0' && ch <= '9';
        }

        private static bool IsSign(string str)
        {
            return str == "-";
        }

        public static bool IsUnit(string str)
        {
            string[] parts = str.Split(' ');

            foreach (string part in parts)
            {
                if (part.Length > 0)
                {
                    if (!IsSimpleUnit(part))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool IsSimpleUnit(string str)
        {
            // NOTE: [CG, 2022.08.15] Проверка на деление (1/s)
            if (str.Contains('/'))
            {
                string[] parts = str.Split('/');

                foreach (string part in parts)
                {
                    return IsSimpleUnit(part) || part == "1";
                }
            }
            else
            {
                if (str.Contains('^'))
                {
                    string[] parts = str.Split('^');

                    return parts.Length == 2 &&
                        !IsNumber(parts[0]) &&
                        IsNumber(TrimBrackets(parts[1]));
                }
                else
                {
                    return 
                        !str.Contains(' ') &&
                        !IsNumber(str);
                }
            }

            return true;
        }

        private static string TrimBrackets(string str)
        {
            return str
                .TrimStart('(').TrimEnd(')')
                .TrimStart('{').TrimEnd('}')
                .TrimStart('[').TrimEnd(']');
        }

        #endregion
    }
}
