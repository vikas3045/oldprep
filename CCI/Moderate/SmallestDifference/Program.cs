using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrA = { 1, 3, 15, 11, 2 };
            int[] arrB = { 23, 127, 235, 19, 8 };

            var result = SmallestDifference(arrA, arrB);

            Console.ReadLine();
        }

        private static int SmallestDifference(int[] arrA, int[] arrB)
        {
            Array.Sort(arrA);
            Array.Sort(arrB);

            int aIndex = 0;
            int bIndex = 0;
            int minDiff = int.MaxValue;

            while (aIndex < arrA.Length && bIndex < arrB.Length)
            {
                minDiff = Math.Min(minDiff, Math.Abs(arrA[aIndex] - arrB[bIndex]));

                if (arrA[aIndex] > arrB[bIndex])
                    bIndex++;
                else
                    aIndex++;
            }

            return minDiff;
        }
    }
}
