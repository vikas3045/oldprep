using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { -2, 2, -1, 3, 4 };

            Console.WriteLine(MaxDifference(arr));

            Console.ReadLine();
        }

        private static int MaxDifference(int[] arr)
        {
            int n = arr.Length;
            int left = arr[0];
            int right = arr[0];
            int maxDiff = 0;

            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = i + 1; j <= n - 1; j++)
                {
                    int diff = arr[j] - arr[i];
                    if (diff > maxDiff)
                    {
                        left = i;
                        right = j;
                        maxDiff = diff;
                    }
                }
            }

            return maxDiff;
        }
    }
}
