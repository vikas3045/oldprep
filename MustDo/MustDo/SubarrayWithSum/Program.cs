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
            int[] arr = { 1, 4, 20, 3, 10, 5 };
            int sum = 33;

            SubarrayWithSum(arr, sum);

            Console.ReadLine();
        }

        private static void SubarrayWithSum(int[] arr, int sum)
        {
            if (arr == null) return;
            SubarrayWithSum(arr, 0, arr.Length - 1, 0, sum);
        }

        private static void SubarrayWithSum(int[] arr, int curPos, int end, int posStart, int sum)
        {
            if (curPos > end)
                return;

            if (curPos == end && arr[curPos] != sum)
                return;

            if (arr[curPos] == sum)
            {
                Console.WriteLine("Sum found between indexes {0} and {1}", posStart, curPos);
                return;
            }
            else if (arr[curPos] > sum)
            {
                SubarrayWithSum(arr, curPos + 1, end, curPos + 1, sum);
            }
            else
            {
                SubarrayWithSum(arr, curPos + 1, end, curPos, sum - arr[curPos]);
                SubarrayWithSum(arr, curPos + 1, end, curPos + 1, sum);
            }
        }
    }
}
