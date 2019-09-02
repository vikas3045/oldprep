using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 };
            FindRangeToBeSorted(arr);

            Console.ReadLine();
        }

        private static void FindRangeToBeSorted(int[] arr)
        {
            if (arr.Length == 0)
                return;

            int leftMaxIndex = arr[0];
            int rightMinIndex = arr[arr.Length - 1];

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    leftMaxIndex = i;
                    break;
                }
            }


            for (int i = arr.Length - 1; i > 0; i--)
            {
                if (arr[i] < arr[i - 1])
                {
                    rightMinIndex = i;
                    break;
                }
            }

            // tbd case if its already sorted

            int midMin = int.MaxValue;
            int midMax = int.MinValue;

            for (int i = leftMaxIndex + 1; i < rightMinIndex; i++)
            {
                midMin = Math.Min(midMin, arr[i]);
                midMax = Math.Max(midMax, arr[i]);
            }

            int startIndex = 0;
            int endIndex = arr.Length - 1;
            // Find appropriate index for min and max
            for (int i = 0; i < leftMaxIndex; i++)
            {
                if (midMin < arr[i])
                {
                    startIndex = i - 1;
                    break;
                }
            }

            for (int i = rightMinIndex; i < arr.Length - 1; i++)
            {
                if (arr[i] > midMax)
                {
                    endIndex = i - 1;
                    break;
                }
            }

            Console.WriteLine("Indices are {0} - {1}", startIndex, endIndex);
        }
    }
}
