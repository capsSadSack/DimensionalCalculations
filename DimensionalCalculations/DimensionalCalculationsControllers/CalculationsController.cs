using DimensionalCalculations;
using DimensionalCalculations.DimensionOperations;
using MathEquationParsing;

namespace DimensionalCalculationsControllers
{
    public class CalculationsController
    {
        private readonly Dictionary<Operator, char> _operators = new Dictionary<Operator, char>()
        {
            { Operator.Plus, '+' },
            { Operator.Minus, '-' },
            { Operator.Multiply, '*' },
            { Operator.Divide, '/' }
        };

        public string ProcessString(string str)
        {
            str = str.Replace("\r", "").Replace("\n", "");

            SplitPhysicalQuantitiesAndOperators(str,
                out List<PhysicalQuantity> pqs, out List<Operator> operators);

            PhysicalQuantity result = pqs[0];

            for (int i = 1; i < pqs.Count(); i++)
            {
                PhysicalQuantity pq = pqs[i];

                switch(operators[i - 1])
                {
                    case Operator.Plus: result += pq; break;
                    case Operator.Minus: result -= pq; break;
                    case Operator.Multiply: result *= pq; break;
                    case Operator.Divide: result /= pq; break;                  
                }
            }

            string pqStr = DimensionSimplifier.ConvertToString(result, SystemOfUnits.SystemInternational);
            return pqStr;
        }

        private void SplitPhysicalQuantitiesAndOperators(string str, 
            out List<PhysicalQuantity> pqs, out List<Operator> operators)
        {
            pqs = new List<PhysicalQuantity>();
            operators = new List<Operator>();

            IEnumerable<string> parts = SplitAfterOperator(str);

            foreach (var part in parts)
            {
                SplitPqFromOperator(part, out string pqStr, out Operator? op);

                PhysicalQuantity pq = PhysicalQuantityParsing.ParsePhysicalQuantity(pqStr);
                pqs.Add(pq);
                if(op != null)
                {
                    operators.Add((Operator)op);
                }
            }
        }

        private IEnumerable<string> SplitAfterOperator(string str)
        {
            string formattedStr = str.Replace(" ", "");

            if (formattedStr.Length  == 0)
            {
                throw new ArgumentException("Wrong string format. String must contain symbols to be parsed.");
            }
            else if(formattedStr.Length > 0 && !IsNumber(formattedStr.First()))
            {
                throw new ArgumentException("Wrong string format. String must be started with number.");
            }

            List<string> output = new List<string>();
            List<int> splitIndexes = new List<int>() { 0 };

            for (int i = 0; i < formattedStr.Length - 1; i++)
            {
                char currCh = formattedStr[i];
                char nextCh = formattedStr[i + 1];

                if (IsOperator(currCh) && IsNumber(nextCh))
                {
                    splitIndexes.Add(i + 1);
                }
            }
            splitIndexes.Add(formattedStr.Length);

            for (int i = 0; i < splitIndexes.Count - 1; i++)
            {
                int start = splitIndexes[i];
                int length = splitIndexes[i + 1] - splitIndexes[i];
                string substring = formattedStr.Substring(start, length);

                output.Add(substring);
            }

            return output;
        }

        private bool IsNumber(char ch)
        {
            return ch >= '0' && ch <= '9';
        }

        private bool IsOperator(char ch)
        {
            return _operators.Values.Any(op => op == ch);
        }

        private void SplitPqFromOperator(string str, out string pqStr, out Operator? op)
        {
            List<char> operatorsChars = _operators.Values.ToList();
                       
            if(operatorsChars.Any(opCh => str.EndsWith(opCh)))
            {
                pqStr = str.Substring(0, str.Length - 1);
                op = _operators
                    .Where(x => x.Value == str.Last())
                    .Select(x => x.Key)
                    .FirstOrDefault();
            }
            else
            {
                pqStr = str;
                op = null;
            }
        }

        private enum Operator
        {
            Plus,
            Minus,
            Multiply,
            Divide
        }
    }
}