using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using DimensionalCalculations;
using DimensionalCalculations.Units;
using DimensionalCalculations.Units.UnitsAmountOfSubstance;
using DimensionalCalculations.Units.UnitsCurrent;
using DimensionalCalculations.Units.UnitsLength;
using DimensionalCalculations.Units.UnitsLuminousIntensity;
using DimensionalCalculations.Units.UnitsMass;
using DimensionalCalculations.Units.UnitsTemperature;
using DimensionalCalculations.Units.UnitsTime;
using MathEquationParsing.Exceptions;
using MathEquationParsing.Models;

[assembly: InternalsVisibleTo("MathEquationParsing.Tests")]

namespace MathEquationParsing
{
    // NOTE: [CG, 2022.08.10] Brackets problems:
    // - unable to parse brackets in brackets, etc.
    // -
    public static class UnitParsing
    {
        public static AbstractUnit GetUnit(string str)
        {
            if(str == "")
            {
                return new DimensionlessUnit();
            }

            if(//str.Contains('+') || str.Contains('-') || 
                str.Contains('/'))
            {
                throw new IncorrectUnitException($"Incorrect unit string: \"{ str }\".");
            }

            string simplifiedStr = Simplify(str);

            string[] parts = simplifiedStr.Split(' ', '*')
                    .Where(x => x.Length > 0)
                    .ToArray();
            AbstractUnit output = new DimensionlessUnit();

            foreach(var part in parts)
            {
                GetUnitAndPower(part, out string unitStr, out int power);

                for (int i = 0; i < Math.Abs(power); i++)
                {
                    AbstractUnit unit = SingleUnitParsing.ParseSingleUnit(unitStr);
                    if(power > 0)
                    {
                        output *= unit;
                    }
                    else if (power < 0)
                    {
                        output /= unit;
                    }
                }
            }

            return output;
        }

        private static string Simplify(string str)
        {
            str = str.Trim(' ');

            if (str == "1")
            {
                return "";
            }

            return SimplifyPowers(str);
        }

        /// <summary>
        /// Split complex equation into single fraction with dividend and divisor
        /// </summary>
        /// <param name="str">Math equation string</param>
        /// <param name="dividend">Result dividend</param>
        /// <param name="divisor">Result divisor</param>
        private static void MinimizeDivisionSigns(string str, out string dividend, out string divisor)
        {
            dividend = "";
            divisor = "";

            if (str.Contains('/'))
            {
                string[] parts = str
                    .Split('/')
                    .Select(x => x.Trim(' '))
                    .Where(x => x.Length > 0)
                    .ToArray();

                dividend += RemoveBrackets(parts[0]) + ' ';
              
                for (int i = 1; i < parts.Count(); i++)
                {
                    string firstStr = string.Empty;
                    string remainsStr = string.Empty;

                    if (parts[i].Contains('(') && parts[i].Contains(' ') && parts[i].IndexOf('(') < parts[i].IndexOf(' '))
                    {
                        CutFirstBracket(parts[i], out firstStr, out remainsStr);
                    }
                    else
                    {
                        string[] partsParts = parts[i]
                            .Split(' ', '*')
                            .Select(x => x.Trim(' '))
                            .Where(x => x.Length > 0)
                            .ToArray();

                        firstStr = partsParts[0];
                        remainsStr = parts[i].Substring(firstStr.Length).Trim(' ');
                    }


                    divisor += firstStr + ' ';

                    string[] remainsParts = remainsStr
                        .Split(' ', '*')
                        .Select(x => x.Trim(' '))
                        .Where(x => x.Length > 0)
                        .ToArray();

                    for (int j = 0; j < remainsParts.Count(); j++)
                    {
                        dividend += remainsParts[j] + ' ';
                    }
                }
            }
            else
            {
                dividend = str;
                divisor = "";
            }
        }

        private static string RemoveBrackets(string str)
        {
            return str
                .Replace("(", " ")
                .Replace(")", " ")
                .Replace("{", " ")
                .Replace("}", " ")
                .Replace("[", " ")
                .Replace("]", " ")
                .Replace("  ", " ");
        }

        private static void CutFirstBracket(string str, out string insideBracketsStr, out string remainsStr)
        {
            int? openIndex = null;
            int? closeIndex = null;

            for(int i = 0; i < str.Count(); i++)
            {
                if(str[i] == '(')
                {
                    openIndex = i;

                    if(openIndex != 0)
                    {
                        throw new Exception();
                    }
                }

                if(str[i] == ')')
                {
                    closeIndex = i;
                }

                if(openIndex != null && closeIndex != null)
                {
                    insideBracketsStr = str.Substring((int)openIndex + 1, (int)closeIndex - (int)openIndex - 1);
                    remainsStr = str.Substring((int)closeIndex + 1);
                    return;
                }
            }

            throw new Exception();
        }

        /// <summary>
        /// Find same units and simplify their powers
        /// </summary>
        /// <param name="str">Units string</param>
        /// <returns>Units string with unique units with powers</returns>
        private static string SimplifyPowers(string str)
        {
            Dictionary<string, int> units = new Dictionary<string, int>();
            string[] parts = str.Replace("  ", " ").Split(' ');

            foreach (string part in parts)
            {
                GetUnitAndPower(part, out string unit, out int power);

                if (!units.ContainsKey(unit))
                {
                    units.Add(unit, 0);
                }

                int prevPower = units[unit];
                units[unit] = prevPower + power;
            }

            string output = string.Empty;
            foreach (var item in units)
            {
                if (item.Value != 0)
                {
                    output += FromUnitAndPower(item.Key, item.Value) + " ";
                }
            }

            return output;
        }

        private static string InversePowers(string str)
        {
            str = str.Trim(' ');

            if (str.Contains('/'))
            {
                throw new Exception();
            }

            string[] parts = str.Split(' ');

            Dictionary<string, int> units = new Dictionary<string, int>();
            foreach(string part in parts)
            {
                GetUnitAndPower(part, out string unit, out int power);

                if(!units.ContainsKey(unit))
                {
                    units.Add(unit, 0);
                }

                int prevPower = units[unit];
                units[unit] = prevPower + power;
            }

            string output = string.Empty;
            foreach(var item in units)
            {
                output += FromUnitAndPower(item.Key, -item.Value) + " ";
            }

            return output;
        }

        private static string FromUnitAndPower(string unit, int power)
        {
            string str = $"{ unit }^({ power })";
            return str;
        }

        private static void GetUnitAndPower(string unitWithPowerStr, out string unit, out int power)
        {
            string str = unitWithPowerStr.Replace(" ", "");

            if(str.Contains('^'))
            {
                string[] parts = str.Split('^');

                unit = parts[0];
                power = Convert.ToInt32(parts[1].Trim('(').Trim(')'));
            }
            else
            {
                unit = str;
                power = 1;
            }
        }

        private static void SplitByLastChar(string str, char ch, out string left, out string right)
        {
            if(!str.Contains(ch))
            {
                left = str;
                right = "";
                return;
            }

            for(int i = str.Length - 1; i >= 0 ; i--)
            {
                if(str[i] == ch)
                {
                    left = str.Substring(0, i);
                    right = str.Substring(i + 1);

                    return;
                }
            }

            throw new Exception($"Char '{ ch }' was not found in string.");
        }


    }
}
