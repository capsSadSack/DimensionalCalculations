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
        private static bool IsMatchingPair(char character1, char character2)
        {
            if (AreOpenAndCloseBrackets(character1, character2))
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
                if (IsOpenedBracket(exp[i]))
                {
                    st.Push(exp[i]);
                }

                //  If exp[i] is an ending bracket
                //  then pop from stack and check if the
                //   popped bracket is a matching pair
                if (IsClosedBracket(exp[i]))
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

        private static bool AreOpenAndCloseBrackets(char ch1, char ch2)
        {
            return
                ch1 == '(' && ch2 == ')' ||
                ch1 == '{' && ch2 == '}' ||
                ch1 == '[' && ch2 == ']';
        }

        private static bool IsOpenedBracket(char ch)
        {
            return ch == '{' ||
                   ch == '(' ||
                   ch == '[';
        }

        private static bool IsClosedBracket(char ch)
        {
            return ch == '}' ||
                   ch == ')' ||
                   ch == ']';
        }

        public static string RemoveUselessBrackets(string str)
        {
            IEnumerable<(int, int)> bracketPairIndexes = GetBracketPairIndexes(str)
                .OrderBy(x => x.Item1);
            List<(int, int)> pairsToRemove = new List<(int, int)>();

            for (int i = 0; i < bracketPairIndexes.Count() - 1; i++)
            {
                var first = bracketPairIndexes.ElementAt(i);
                var second = bracketPairIndexes.ElementAt(i + 1);

                if (first.Item1 == second.Item1 - 1 &&
                    first.Item2 == second.Item2 + 1)
                {
                    pairsToRemove.Add(first);
                }
            }

            List<int> indexesToRemove = new List<int>();
            foreach(var pair in pairsToRemove)
            {
                indexesToRemove.Add(pair.Item1);
                indexesToRemove.Add(pair.Item2);
            }
            indexesToRemove = indexesToRemove.OrderByDescending(x => x).ToList();

            string output = str;
            foreach(int index in indexesToRemove)
            {
                output = output.Remove(index, 1);
            }

            return output;
        }

        private static IEnumerable<(int, int)> GetBracketPairIndexes(string str)
        {
            List<(int, int)> output = new List<(int, int)>();
            Stack<(char BracketChar, int Index)> stack = new();

            for (int i = 0; i < str.Length; i++)
            {
                if (IsOpenedBracket(str[i]))
                {
                    stack.Push((str[i], i));
                }

                if (IsClosedBracket(str[i]))
                {
                    if (stack.Count == 0)
                    {
                        throw new IncorrectBracketsException("");
                    }
                    else
                    {
                        var lastItem = stack.Pop();
                        if (IsMatchingPair(lastItem.BracketChar, str[i]))
                        {
                            output.Add((lastItem.Index, i));
                        }
                        else
                        {
                            throw new IncorrectBracketsException("");
                        }
                    }
                }
            }

            if (stack.Count == 0)
            {
                return output;
            }
            else
            {
                throw new IncorrectBracketsException("Brackets stack is unbalanced.");
            }
        }

        public static bool NoNestedBrackets(string str)
        {
            BracketState currentState = BracketState.None;

            for (int i = 0; i < str.Count(); i++)
            {
                if (currentState == BracketState.None)
                {
                    if (IsOpenedBracket(str[i]))
                    {
                        currentState = BracketState.OpenedBracket;
                    }
                    else if (IsClosedBracket(str[i]))
                    {
                        throw new ArgumentException($"String has wrong format: {str}.");
                    }
                }
                else if (currentState == BracketState.OpenedBracket)
                {
                    if (IsOpenedBracket(str[i]))
                    {
                        return false;
                    }
                    else if (IsClosedBracket(str[i]))
                    {
                        currentState = BracketState.None;
                    }
                }
            }

            return currentState == BracketState.None;
        }
        
        private enum BracketState
        {
            None,
            OpenedBracket,
            ClosedBracket
        }
    }
}
