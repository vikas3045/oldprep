using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            ///
            /// Given an array arr[], find the maximum j – i such that arr[j] > arr[i]
            ///

            int[] arr = { 9, 2, 3, 4, 5, 6, 7, 8, 18, 0 };

            //Console.WriteLine(MaximumIndex(arr));

            Console.WriteLine(MaximumIndex(arr, arr.Length));

            Console.ReadLine();
        }

        // EFFICIENT APPROACH

        // For a given array arr[], returns 
        // the maximum j-i such thatarr[j] > arr[i] 
        static int MaximumIndex(int[] arr, int n)
        {
            int maxDiff;
            int i, j;

            int[] RMax = new int[n];
            int[] LMin = new int[n];

            // Construct LMin[] such that LMin[i] 
            // stores the minimum value
            // from (arr[0], arr[1], ... arr[i]) 
            LMin[0] = arr[0];
            for (i = 1; i < n; ++i)
                LMin[i] = Math.Min(arr[i], LMin[i - 1]);

            // Construct RMax[] such that 
            // RMax[j] stores the maximum value
            // from (arr[j], arr[j+1], ..arr[n-1]) 
            RMax[n - 1] = arr[n - 1];
            for (j = n - 2; j >= 0; --j)
                RMax[j] = Math.Max(arr[j], RMax[j + 1]);

            // Traverse both arrays from left 
            // to right to find optimum j - i
            // This process is similar to merge() 
            // of MergeSort 
            i = 0; j = 0; maxDiff = -1;
            while (j < n && i < n)
            {
                if (LMin[i] < RMax[j])
                {
                    maxDiff = Math.Max(maxDiff, j - i);
                    j = j + 1;
                }
                else
                    i = i + 1;
            }

            return maxDiff;
        }


        private static int MaximumIndex(int[] arr)
        {
            Dictionary<int, int> dicPossibleResult = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int maxj = i + 1;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] > arr[i])
                    {
                        maxj = Math.Max(maxj, j);
                    }
                }

                dicPossibleResult.Add(i, maxj);
            }

            int maxSoFar = int.MinValue;

            foreach (KeyValuePair<int, int> pair in dicPossibleResult)
            {
                maxSoFar = Math.Max(maxSoFar, pair.Value - pair.Key);
            }

            return maxSoFar;
        }
    }
}
