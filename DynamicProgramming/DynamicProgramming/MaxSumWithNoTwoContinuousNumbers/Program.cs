using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumWithNoTwoContinuousNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 100, 1000, 100, 1000, 1 };

            //Console.WriteLine(MaxSumWithNoTwoContinuousNumbers(arr));
            //Console.WriteLine(MaxSumWithNoTwoContinuousNumbersMemo(arr));
            Console.WriteLine(MaxSumWithNoThreeContinuousNumbersMemo(arr));

            Console.ReadLine();
        }

        private static int MaxSumWithNoTwoContinuousNumbers(int[] arr)
        {
            int maxSumIncluding = arr[0];
            int maxSumExcluding = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                int prevMaxIncluding = maxSumIncluding;
                maxSumIncluding = maxSumExcluding + arr[i];
                maxSumExcluding = Math.Max(prevMaxIncluding, maxSumExcluding);
            }

            return Math.Max(maxSumIncluding, maxSumExcluding);
        }

        private static int MaxSumWithNoTwoContinuousNumbersMemo(int[] arr)
        {
            int[] M = new int[arr.Length];

            M[0] = arr[0];
            M[1] = (arr[0] > arr[1] ? arr[0] : arr[1]);

            for (int i = 2; i < arr.Length; i++)
            {
                M[i] = Math.Max(arr[i] + M[i - 2], M[i - 1]);
            }

            return M[arr.Length - 1];
        }

        private static int MaxSumWithNoThreeContinuousNumbersMemo(int[] arr)
        {
            int[] M = new int[arr.Length];

            M[0] = arr[0];
            M[1] = arr[0] + arr[1];
            int temp = Math.Max(arr[2] + arr[1], arr[0] + arr[2]);
            M[2] = Math.Max(temp, M[1]);

            for (int i = 3; i < arr.Length; i++)
            {
                int tempMax = Math.Max(arr[i] + arr[i - 1] + M[i - 3], arr[i] + M[i - 2]);
                M[i] = Math.Max(tempMax, M[i - 1]);
            }

            return M[arr.Length - 1];
        }
    }
}
