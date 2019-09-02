using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPossibleSubsets
{

    /*Elements in a subset must be in non-descending order.
      The solution set must not contain duplicate subsets.
      Also, the subsets should be sorted in ascending (lexicographic ) order.
      The list is not necessarily sorted.*/

    class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = new List<int>() { 1, 2, 3 };
            var result = Subsets(arr);

            Console.ReadLine();
        }

        public static List<List<int>> Subsets(List<int> arr)
        {
            if (arr == null)
                return null;
            arr.Sort();
            List<int> emptySet = new List<int>();
            List<List<int>> lstResult = new List<List<int>>();
            lstResult.Add(emptySet);

            SubsetsUtilAlt(arr, 0, lstResult);

            return lstResult;
        }

        private static void SubsetsUtilAlt(List<int> arr, int curIndex, List<List<int>> lstResult)
        {
            if (curIndex >= arr.Count)
                return;

            var lstSoFar = lstResult[lstResult.Count - 1];

            for (int i = curIndex; i < arr.Count; i++)
            {
                var sub = new List<int>(lstSoFar);
                sub.Add(arr[i]);
                lstResult.Add(sub);
                SubsetsUtilAlt(arr, i + 1, lstResult);
            }
        }

        private static void SubsetsUtil(List<int> arr, int curIndex, List<List<int>> lstResult)
        {
            if (curIndex >= arr.Count)
                return;

            // exclude current element
            SubsetsUtil(arr, curIndex + 1, lstResult);

            // include current element
            List<List<int>> lstIncl = new List<List<int>>();
            foreach (var list in lstResult)
            {
                var clone = new List<int>(list);
                clone.Add(arr[curIndex]);
                lstIncl.Add(clone);
            }

            lstResult.AddRange(lstIncl);
        }
    }
}
