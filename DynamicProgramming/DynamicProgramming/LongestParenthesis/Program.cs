using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = ")()()";
            var result = LongestParenthesis(str);

            Console.ReadLine();
        }

        private static int LongestParenthesis(string str)
        {
            if (str.Length == 0)
                return 0;

            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            int result = 0;

            for (int i = 0; i <= str.Length - 1; i++)
            {
                if (str[i] == '(')
                    stack.Push(i);
                else if (str[i] == ')')
                {
                    stack.Pop();

                    if (stack.Count > 0)
                        result = Math.Max(result, i - stack.Peek());
                    else
                        stack.Push(i);
                }
            }

            return result;
        }
    }
}
