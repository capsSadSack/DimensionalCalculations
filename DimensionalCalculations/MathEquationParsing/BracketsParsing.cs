using MathEquationParsing.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEquationParsing
{
    public static class BracketsParsing
    {
        private class Stack
        {
            private List<char> _items = new List<char>();

            public void Push(char x)
            {
                _items.Add(x);
            }

            public char Pop()
            {
                if (_items.Count() == 0)
                {
                    throw new Exception("Stack is empty exception.");
                }
                else
                {
                    char element = _items.Last();
                    _items.RemoveAt(_items.Count() - 1);
                    return element;
                }
            }

            public bool IsEmpty()
            {
                return _items.Count() == 0;
            }
        }

        // Returns true if character1 and character2
        // are matching left and right brackets */
        private static bool IsMatchingPair(char character1,
                                      char character2)
        {
            if (character1 == '(' && character2 == ')' ||
                character1 == '{' && character2 == '}' ||
                character1 == '[' && character2 == ']')
            {
                return true;
            }

            return false;
        }

        // Return true if expression has balanced
        // Brackets
        public static bool CheckBrackets(string exp)
        {
            // Declare an empty character stack */
            Stack<char> st = new Stack<char>();

            // Traverse the given expression to
            //   check matching brackets
            for (int i = 0; i < exp.Length; i++)
            {
                // If the exp[i] is a starting
                // bracket then push it
                if (exp[i] == '{' ||
                    exp[i] == '(' ||
                    exp[i] == '[')
                {
                    st.Push(exp[i]);
                }

                //  If exp[i] is an ending bracket
                //  then pop from stack and check if the
                //   popped bracket is a matching pair
                if (exp[i] == '}' || 
                    exp[i] == ')' || 
                    exp[i] == ']')
                {

                    // If we see an ending bracket without
                    //   a pair then return false
                    if (st.Count == 0)
                    {
                        return false;
                    }

                    // Pop the top element from stack, if
                    // it is not a pair brackets of
                    // character then there is a mismatch. This
                    // happens for expressions like {(})
                    else if (!IsMatchingPair(st.Pop(), exp[i]))
                    {
                        return false;
                    }
                }
            }

            // If there is something left in expression
            // then there is a starting bracket without
            // a closing bracket

            if (st.Count == 0)
                return true; // balanced
            else
            {
                // not balanced
                return false;
            }
        }

        public static bool ContainsOnlyPowerBrackets(string str)
        {
            throw new NotImplementedException();
        }

        public static bool IsPhysQuantity(string str)
        {
            string[] parts = str.Trim(' ').Split(' ');

            throw new NotImplementedException();
        } 

        public static string CutInnerBrackets(string str, 
            out string remainsLeftStr, out string remainsRightStr)
        {
            remainsLeftStr = String.Empty;
            remainsRightStr = String.Empty;

            if (CheckBrackets(str))
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new IncorrectBracketsException();
            }
        }
    }
}
