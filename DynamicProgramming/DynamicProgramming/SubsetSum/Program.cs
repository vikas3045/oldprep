using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 20, 3, 5, 10 };
            int sum = 33;

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            Console.WriteLine(IsSubsetSumDP(arr, sum));
            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            Console.WriteLine(IsSubsetSum(arr, 0, sum));
            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            watch.Restart();
            Dictionary<string, bool> dicMemo = new Dictionary<string, bool>();
            Console.WriteLine(IsSubsetSumAlt(arr, 0, sum, dicMemo));
            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            Console.ReadLine();
        }

        private static bool IsSubsetSumAlt(int[] arr, int curPos, int sum, Dictionary<string, bool> dicMemo)
        {
            int n = arr.Length;

            if (curPos >= n) return false;

            if (arr[curPos] == sum)
            {
                return true;
            }
            else if (arr[curPos] > sum)
            {
                var key = curPos + 1 + "|" + sum;
                if (!dicMemo.ContainsKey(key))
                {
                    dicMemo.Add(key, IsSubsetSumAlt(arr, curPos + 1, sum, dicMemo));
                    return dicMemo[key];
                }
                else
                {
                    Console.WriteLine("value used at " + key);
                    return dicMemo[key];
                }
            }
            else if (arr[curPos] < sum)
            {
                var includingCurrentKey = curPos + 1 + "|" + (sum - arr[curPos]);
                var excludingCurrentKey = curPos + 1 + "|" + sum;

                if (!dicMemo.ContainsKey(includingCurrentKey))
                {
                    dicMemo.Add(includingCurrentKey, IsSubsetSumAlt(arr, curPos + 1, sum - arr[curPos], dicMemo));
                }
                else
                {
                    Console.WriteLine("value used at " + includingCurrentKey);
                }

                if (!dicMemo.ContainsKey(excludingCurrentKey))
                {
                    dicMemo.Add(excludingCurrentKey, IsSubsetSumAlt(arr, curPos + 1, sum, dicMemo));
                }
                else
                {
                    Console.WriteLine("value used at " + excludingCurrentKey);
                }

                return dicMemo[includingCurrentKey] || dicMemo[excludingCurrentKey];
            }

            return false;
        }

        private static bool IsSubsetSum(int[] arr, int curPos, int sum)
        {
            int n = arr.Length;

            if (curPos >= n) return false;

            if (arr[curPos] == sum)
            {
                return true;
            }
            else if (arr[curPos] > sum)
            {
                return IsSubsetSum(arr, curPos + 1, sum);
            }
            else if (arr[curPos] < sum)
                return IsSubsetSum(arr, curPos + 1, sum - arr[curPos]) || IsSubsetSum(arr, curPos + 1, sum);

            return false;
        }

        private static bool IsSubsetSumDP(int[] arr, int sum)
        {
            bool[,] memo = new bool[arr.Length + 1, sum + 1];

            for (int row = 0; row < memo.GetLength(0); row++)
            {
                memo[row, 0] = true;
            }

            for (int col = 1; col < memo.GetLength(1); col++)
            {
                memo[0, col] = false;
            }

            for (int row = 1; row < memo.GetLength(0); row++)
            {
                for (int col = 1; col < memo.GetLength(1); col++)
                {
                    memo[row, col] = memo[row - 1, col];

                    if (col >= arr[row - 1])
                        memo[row, col] = memo[row, col] || memo[row - 1, col - arr[row - 1]];
                }
            }

            return memo[arr.Length, sum];
        }
    }
}
