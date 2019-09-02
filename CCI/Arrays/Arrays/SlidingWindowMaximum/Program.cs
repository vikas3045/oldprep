using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindowMaximum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 8, 5, 10, 7, 9, 4, 15, 12, 90, 13 };

            SlidingWindowMaximum(arr, 4);
            Console.WriteLine();
            SlidingWindowMaxAlt(arr, 4);

            Console.ReadLine();
        }

        private static void SlidingWindowMaximum(int[] arr, int k)
        {
            int start = 0;
            int end = k - 1;

            while (end < arr.Length)
            {
                int max = int.MinValue;

                for (int i = start; i <= end; i++)
                {
                    if (max < arr[i])
                    {
                        max = arr[i];
                    }
                }

                Console.Write(max + " ");
                max = int.MinValue;

                start++;
                end++;
            }
        }

        private static void SlidingWindowMaxAlt(int[] arr, int k)
        {
            for (int i = 0; i + k <= arr.Length; i++)
            {
                int start = i;
                int end = i + k;
                int max = arr[start];

                while (start < end)
                {
                    max = Math.Max(max, arr[start]);
                    start++;
                }
                Console.Write(max + " ");
            }
        }
    }
}
