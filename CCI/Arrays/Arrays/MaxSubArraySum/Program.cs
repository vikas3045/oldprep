using System;

namespace MaxSubArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { -8, -3, -6, -2, -5, -4 };
            Console.WriteLine(PrintMaxSubArraySum(arr));
            Console.WriteLine();
            Console.WriteLine(MaxSubArraySum(arr));
            Console.WriteLine();

            //Console.WriteLine(MaxSubArraySum(arr, 8));

            Console.ReadLine();
        }

        private static int MaxSubArraySum(int[] arr)
        {
            int maxSum = arr[0];
            int maxEndingHere = 0;

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                maxEndingHere = maxEndingHere + arr[i];

                if (maxEndingHere > maxSum)
                    maxSum = maxEndingHere;

                if (maxEndingHere < 0)
                    maxEndingHere = 0;
            }

            return maxSum;
        }

        private static int PrintMaxSubArraySum(int[] arr)
        {
            int maxSum = arr[0];
            int maxEndingHere = 0;
            int left = 0;
            int right = 0;
            int leftTemp = 0;

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                maxEndingHere = maxEndingHere + arr[i];

                if (maxEndingHere > maxSum)
                {
                    maxSum = maxEndingHere;
                    left = leftTemp;
                    right = i;
                }

                if (maxEndingHere < 0)
                {
                    maxEndingHere = 0;
                    leftTemp = i + 1;
                }
            }

            for (int i = left; i <= right; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();

            return maxSum;
        }

        private static int MaxSubArraySum(int[] a, int size)
        {
            int max_so_far = a[0];
            int curr_max = a[0];

            for (int i = 1; i < size; i++)
            {
                curr_max = Math.Max(a[i], curr_max + a[i]);
                max_so_far = Math.Max(max_so_far, curr_max);
            }

            return max_so_far;
        }
    }
}
