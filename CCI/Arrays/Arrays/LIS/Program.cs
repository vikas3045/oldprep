using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 12, 18, 7, 34, 30, 28, 90, 88 };
            Console.WriteLine("Length of Longest Increasing Subsequence: " + LIS(array, -1, 0));
            Console.WriteLine("Length of Longest Increasing Subsequence: " + LongestIncreasingSubsequence(array));

            Console.ReadLine();
        }

        public static int LIS(int[] arr, int prev, int curPos)
        {
            if (curPos >= arr.Length)
                return 0;

            int taken = 0;
            if (arr[curPos] > prev)
            {
                taken = 1 + LIS(arr, arr[curPos], curPos + 1);
            }

            int notTaken = LIS(arr, prev, curPos + 1);

            return Math.Max(taken, notTaken);
        }

        public static int LongestIncreasingSubsequence(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                return 0;
            }

            int n = input.Length;
            // lisLength[i] = Length of Longest Increasing Subsequence in input[0..i]
            int[] lisLength = new int[n];
            int maxLength = 1;
            lisLength[0] = 1;
            for (int i = 1; i < n; i++)
            {
                lisLength[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (input[i] > input[j] && lisLength[i] < lisLength[j] + 1)
                    {
                        lisLength[i] = lisLength[j] + 1;
                    }
                }
                // Update the length of longest increasing subsequence found till now
                if (maxLength < lisLength[i])
                {
                    maxLength = lisLength[i];
                }
            }
            return maxLength;
        }
    }
}
