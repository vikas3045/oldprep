using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Combine(4, 2);

            Console.ReadLine();
        }
        public static List<List<int>> Combine(int n, int k)
        {
            List<List<int>> lstResult = new List<List<int>>();

            for (int i = 1; i <= n; i++)
            {
                List<int> combination = new List<int>() { i };
                GetCombinations(n, i, k - 1, combination, lstResult);
            }

            return lstResult;
        }

        private static void GetCombinations(int n, int curNumber, int k, List<int> currentCombination, List<List<int>> lstResult)
        {
            if (curNumber > n) return;

            if (k == 0)
            {
                lstResult.Add(currentCombination);
                return;
            }

            for (int i = curNumber + 1; i <= n; i++)
            {
                var subCombination = new List<int>(currentCombination);
                subCombination.Add(i);
                GetCombinations(n, i, k - 1, subCombination, lstResult);
            }
        }
    }
}
