using System;
using System.Collections.Generic;

namespace LIS
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 3, 1, 5, 4, 7, 2, 9, 8, 10, 13, 14, 2, 45, 68, 4, 98, 100 };
            int[] arr = { 3, 10, 2, 1, 20 };

            var watch = new System.Diagnostics.Stopwatch();

            //Console.WriteLine("Rec");
            //watch.Start();
            //Console.WriteLine(LengthOfLISRecursive(arr));
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed);

            //Console.WriteLine();
            //Console.WriteLine("DP");
            //watch.Restart();
            //Console.WriteLine(LengthOfLISDP(arr));
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed);

            Console.WriteLine();
            Console.WriteLine("Dic");
            watch.Restart();
            Result result = new Result();
            result.Val = 1;
            Console.WriteLine(LengthOfLISRecursiveAlt(arr, arr.Length, result));
            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            Console.ReadLine();
        }

        private static int LengthOfLISRecursiveAlt(int[] arr, int n, Result max)
        {
            if (n == 0 || n == 1) return n;

            int result = 0;
            int max_ending_here = 1;

            for (int i = 1; i < n; i++)
            {
                result = LengthOfLISRecursiveAlt(arr, i, max);

                if (arr[i - 1] < arr[i] && result + 1 > max_ending_here)
                    max_ending_here = result + 1;
            }

            if (max.Val < max_ending_here)
                max.Val = max_ending_here;

            // Return length of LIS ending with arr[n-1]
            return max_ending_here;
        }

        private static int LengthOfLISRecursive(int[] arr)
        {
            return LengthOfLISRecursive(arr, int.MinValue, 0);
        }

        private static int LengthOfLISRecursive(int[] arr, int prev, int curPos)
        {
            if (curPos >= arr.Length)
                return 0;

            int taken = 0;
            if (arr[curPos] > prev)
            {
                taken = 1 + LengthOfLISRecursive(arr, arr[curPos], curPos + 1);
            }

            int notTaken = LengthOfLISRecursive(arr, prev, curPos + 1);

            return Math.Max(taken, notTaken);
        }

        private static int LengthOfLISDP(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return 0;

            int[] arrLISLength = new int[arr.Length];
            arrLISLength[0] = 1;
            int maxLength = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                arrLISLength[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j] && arrLISLength[i] < arrLISLength[j] + 1)
                    {
                        arrLISLength[i] = arrLISLength[j] + 1;
                    }
                }

                if (maxLength < arrLISLength[i])
                    maxLength = arrLISLength[i];
            }

            return maxLength;
        }
    }

    internal class Result
    {
        public int Val { get; internal set; }
    }
}
