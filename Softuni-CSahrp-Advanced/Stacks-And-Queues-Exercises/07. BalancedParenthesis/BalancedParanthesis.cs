using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.BalancedParenthesis
{
    class BalancedParanthesis
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            char[] openingBrackets =
            {
                '{',
                '[',
                '('
            };

            char[] closingBrackets =
            {
                '}',
                ']',
                ')'
            };

            bool isBalanced = true;
            
            for (int i = 0; i < input.Length; i++)
            {
                if (openingBrackets.Contains(input[i]))
                {
                    stack.Push(input[i]);
                }

                if (closingBrackets.Contains(input[i]))
                {
                    if (stack.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }

                    isBalanced = CheckIfBalanced(input[i], stack);
                    if (isBalanced == false)
                    {
                        break;
                    }
                    stack.Pop();
                    
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static bool CheckIfBalanced(char ch, Stack<char> stack)
        {
            bool isBalanced = true;

            switch (ch)
            {
                case '}':
                    isBalanced = stack.Peek() == '{' ? true : false;
                    break;
                case ']':
                    isBalanced = stack.Peek() == '[' ? true : false;
                    break;
                case ')':
                    isBalanced = stack.Peek() == '(' ? true : false;
                    break;
                    default:
                        break;
            }

            return isBalanced;
        }
    }
}
