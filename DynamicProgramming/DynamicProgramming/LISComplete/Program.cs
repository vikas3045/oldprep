using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISComplete
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 7, 1, 5, 4, 6 };
            var lis = LISRecursive(arr);
            var lds = LDSRecursive(arr);
        }

        private static int[] LISRecursive(int[] arr)
        {
            List<List<int>> lstResult = new List<List<int>>();
            List<int> curIS = new List<int>();
            LISHelper(arr, int.MinValue, 0, curIS, lstResult);

            return lstResult.OrderByDescending(subList => subList.Count).First().ToArray();
        }

        private static void LISHelper(int[] arr, int prev, int curIndex, List<int> curIS, List<List<int>> lstResult)
        {
            if (curIndex >= arr.Length)
            {
                lstResult.Add(curIS);
                return;
            }

            if (arr[curIndex] > prev)
            {
                List<int> subIS = new List<int>(curIS);
                subIS.Add(arr[curIndex]);
                LISHelper(arr, arr[curIndex], curIndex + 1, subIS, lstResult);
            }

            LISHelper(arr, prev, curIndex + 1, curIS, lstResult);
        }

        private static int[] LDSRecursive(int[] arr)
        {
            List<List<int>> lstResult = new List<List<int>>();
            List<int> curIS = new List<int>();
            LDSHelper(arr, int.MaxValue, 0, curIS, lstResult);

            return lstResult.OrderByDescending(subList => subList.Count).First().ToArray();
        }

        private static void LDSHelper(int[] arr, int prev, int curIndex, List<int> curIS, List<List<int>> lstResult)
        {
            if (curIndex >= arr.Length)
            {
                lstResult.Add(curIS);
                return;
            }

            if (arr[curIndex] < prev)
            {
                List<int> subIS = new List<int>(curIS);
                subIS.Add(arr[curIndex]);
                LDSHelper(arr, arr[curIndex], curIndex + 1, subIS, lstResult);
            }

            LDSHelper(arr, prev, curIndex + 1, curIS, lstResult);
        }
    }
}
