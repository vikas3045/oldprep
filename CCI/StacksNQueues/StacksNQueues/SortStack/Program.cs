using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stack;

namespace SortStack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 1, 4, 5, 3, 2, 10 };
            Stack.Stack<int> stack = new Stack.Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            stack.Print();

            Console.WriteLine();
            var sortedStack = SortStack(stack);
            sortedStack.Print();

            Console.ReadLine();
        }

        public static Stack.Stack<int> SortStack(Stack.Stack<int> stack)
        {
            Stack.Stack<int> rstk = new Stack.Stack<int>();

            while (!stack.IsEmpty())
            {
                int temp = stack.Pop();

                while (!rstk.IsEmpty() && rstk.Peek() > temp)
                {
                    stack.Push(rstk.Pop());
                }

                rstk.Push(temp);
            }

            return rstk;
        }
    }
}
