using System;
using System.Collections.Generic;

namespace StockSpan
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] price = { 80, 50, 60, 70, 60, 75, 85 };
            int n = price.Length;
            int[] S = new int[n];

            PrintArray(price);

            // Fill the span values in array S[]
            CalculateSpan(price, n, S);

            // print the calculated span values
            PrintArray(S);

            Console.ReadLine();
        }

        static void CalculateSpan(int[] price, int n, int[] S)
        {
            // Span value of first day is always 1
            S[0] = 1;

            // Calculate span value of remaining 
            // days by linearly checking previous
            // days
            for (int i = 1; i < n; i++)
            {
                S[i] = 1; // Initialize span value

                // Traverse left while the next 
                // element on left is smaller
                // than price[i]
                for (int j = i - 1; (j >= 0) && (price[i] >= price[j]); j--)
                    S[i]++;
            }
        }

        static void CalculateSpanAlt(int[] price, int n, int[] S)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            S[0] = 1;

            for (int i = 1; i <= n - 1; i++)
            {
                while (stack.Count > 0 && price[stack.Peek()] <= price[i])
                    stack.Pop();

                S[i] = stack.Count > 0 ? i - stack.Peek() : i + 1;
                stack.Push(i);
            }
        }

        // A utility function to print elements 
        // of array
        static void PrintArray(int[] arr)
        {
            string result = string.Join(" ", arr);
            Console.WriteLine(result);
        }
    }
}
