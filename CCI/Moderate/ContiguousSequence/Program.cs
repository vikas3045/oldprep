using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContiguousSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, -8, 3, -2, 4, -10 };
            Console.WriteLine(FindMaxContiguousSum(arr));

            Console.ReadLine();
        }

        private static int FindMaxContiguousSum(int[] arr)
        {
            int maxSum = arr[0];
            int maxEndingHere = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                maxEndingHere += arr[i];

                if (maxEndingHere > maxSum)
                    maxSum = maxEndingHere;

                if (maxEndingHere < 0)
                    maxEndingHere = 0;
            }

            return maxSum;
        }
    }
}
