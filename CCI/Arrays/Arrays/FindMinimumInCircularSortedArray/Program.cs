using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMinimumInCircularSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 4, 5, 6, 7, 0, 1 };

            Console.WriteLine(arr[FindMinimumInCircularSortedArray(arr)]);

            Console.ReadLine();
        }

        private static int FindMinimumInCircularSortedArray(int[] arr)
        {
            int low = 0;
            int high = arr.Length - 1;

            return FindMinimumInCircularSortedArray(arr, low, high);
        }

        private static int FindMinimumInCircularSortedArray(int[] arr, int low, int high)
        {
            if (arr[low] <= arr[high])
                return low;

            int mid = (high + low) / 2;
            int next = (mid + 1) % arr.Length;
            int prev = (mid - 1) % arr.Length;

            if (arr[mid] <= arr[next] && arr[mid] <= arr[prev])
                return mid;

            if (arr[mid] <= arr[high])
                return FindMinimumInCircularSortedArray(arr, low, mid - 1);
            else if (arr[mid] >= arr[low])
                return FindMinimumInCircularSortedArray(arr, mid + 1, high);

            return -1;
        }
    }
}
