using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSubarraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { -2, 11, -4, 13, -5, 2 };
            //Console.WriteLine(MaxSubarraySum(arr));

            Console.WriteLine(MaxSubSumRec(arr, arr.Length - 1));

            Console.ReadLine();
        }

        private static int MaxSubarraySum(int[] arr)
        {
            int[] max = new int[arr.Length];
            max[0] = arr[0];
            int maxValue = int.MinValue;

            for (int i = 1; i < arr.Length; i++)
            {
                max[i] = Math.Max(max[i - 1] + arr[i], arr[i]);

                if (maxValue < max[i])
                    maxValue = max[i];
            }

            return maxValue;
        }

        private static int MaxSubSumRec(int[] arr, int index)
        {
            // Base condition
            throw new NotImplementedException();
        }

        private static int MaxSubNoThreeCont(int[] arr, int index)
        {
            //if (index == 0) return arr[0];
            //else if (index == 1) return arr[0] + arr[1];
            //else if(index == 2) return arr[]

            return Max(arr[index] + arr[index - 1] + MaxSubNoThreeCont(arr, index - 3),
                arr[index] + MaxSubNoThreeCont(arr, index - 2),
                MaxSubNoThreeCont(arr, index - 1));
        }

        private static int Max(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));
        }
    }
}
