using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubarrayWithSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 20, 3, 10, 5, 33, 30, 3 };
            int sum = 33;

            IsSubarrayWithSumPresent(arr, sum);

            Console.ReadLine();
        }

        private static void IsSubarrayWithSumPresent(int[] arr, int sum)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int curSum = 0;
            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                // add current element to curSum
                curSum = curSum + arr[i];

                // if curSum is equal to target sum
                // we found a subarray starting from index 0
                // and ending at index i
                if (curSum == sum)
                {
                    Console.WriteLine("Sum found from {0} to {1}", 0, i);
                    //return;
                }

                // If curSum - sum already exists in map
                // we have found a subarray with target sum
                if (map.ContainsKey(curSum - sum))
                {
                    Console.WriteLine("Sum found from {0} to {1}", map[curSum - sum] + 1, i);
                    //return;
                }

                if (!map.ContainsKey(curSum))
                    map.Add(curSum, i);
                else
                    map[curSum] = i;
            }
        }

        public static void FindSubarraysWithSum(int[] arr, int n, int sum)
        {

        }

        private static void Print(int[] arr, int i, int j)
        {
            Console.WriteLine("From {0} to {1}", i, j);
            for (int k = i; k <= j; k++)
            {
                Console.Write(arr[k] + " ");
            }
            Console.WriteLine();
        }
    }
}
