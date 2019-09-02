using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythagoreanTriplet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 4, 6, 12, 5 };

            Console.WriteLine(PythagoreanTriplet(arr, 0));

            Console.ReadLine();
        }


        // Recursive and not at all efficient as DP cant really solve this

        private static bool PythagoreanTriplet(int[] arr, int currIndex)
        {
            int size = arr.Length;

            if (currIndex >= size)
                return false;

            bool excl = PythagoreanTriplet(arr, currIndex + 1);
            bool inclAsHyp = IsSumOfSquares(arr, currIndex + 1, arr[currIndex]);
            bool inclAsBase = IsDiffOfSquares(arr, currIndex + 1, arr[currIndex]);

            return excl || inclAsBase || inclAsHyp;
        }

        private static bool IsDiffOfSquares(int[] arr, int curIndex, int element)
        {
            int size = arr.Length;

            if (curIndex >= size)
                return false;

            int desiredValue = element * element;
            int currSquare = arr[curIndex] * arr[curIndex];

            for (int i = curIndex; i < size; i++)
            {
                if (desiredValue == Math.Abs(arr[i] * arr[i] - currSquare))
                    return true;
            }

            return IsDiffOfSquares(arr, curIndex + 1, element);
        }

        private static bool IsSumOfSquares(int[] arr, int curIndex, int element)
        {
            int size = arr.Length;

            if (curIndex >= size)
                return false;

            int desiredValue = element * element;
            for (int i = curIndex; i < size; i++)
                if (arr[curIndex] * arr[curIndex] + arr[i] * arr[i] == desiredValue)
                    return true;

            return IsSumOfSquares(arr, curIndex + 1, element);
        }
    }
}
