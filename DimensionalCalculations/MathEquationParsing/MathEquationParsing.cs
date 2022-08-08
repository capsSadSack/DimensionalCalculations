using DimensionalCalculations;
using MathEquationParsing.Exceptions;

namespace MathEquationParsing
{
    public static class MathEquationParsing
    {

        public static PhysicalQuantity ParsePhysicalQuantity(string str)
        {
            Split(str, out string numberStr, out string unitStr);

            double value = Convert.ToDouble(numberStr);
            AbstractUnit unit = ParseUnit(unitStr);
            return new PhysicalQuantity(value, unit);
        }

        private static void Split(string str, out string numberStr, out string unitStr)
        {
            numberStr = "";
            unitStr = "";

            string[] parts = str.Split(' ')
                .Where(x => x.Length > 0)
                .ToArray();

            bool signExpected = true;
            bool numberExpected = true;
            bool unitExpected = false;

            for(int i = 0; i < parts.Count(); i++)
            {
                if(IsSign(parts[i]) && signExpected)
                {
                    numberStr += parts[i];
                    signExpected = false;
                }
                else if(IsNumber(parts[i]) && numberExpected)
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

        private static AbstractUnit ParseUnit(string str)
        {
            // TODO: [CG, 2022.08.02] Предусмотреть деление

            //string[] parts = str.Trim(' ').Split(' ');

            //if(parts.Length > 0)
            //{

            //}

            return UnitParsing.GetUnit(str);
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

        private static bool IsUnit(string str)
        {
            return true;
        }

        #endregion
    }

    public enum EquationPart
    {
        Sign,
        Number,
        Unit,
        Operator
    }
}