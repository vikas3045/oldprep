using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairsWithSum
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 1, 4, 2, 3, 0, 5 };
            int[] arr = { 2, 3, 3, 2 };
            int requiredSum = 5;
            var result = PairsWithSum(arr, requiredSum);

            Console.ReadLine();
        }

        private static List<string> PairsWithSum(int[] arr, int sum)
        {
            Dictionary<int, int> hsElements = new Dictionary<int, int>();
            List<string> lstResult = new List<string>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!hsElements.ContainsKey(arr[i]))
                    hsElements.Add(arr[i], 1);
                else
                    hsElements[arr[i]] += 1;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (hsElements.ContainsKey(sum - arr[i]) && hsElements[sum - arr[i]] > 0)
                {
                    lstResult.Add(arr[i] + ", " + (sum - arr[i]));
                    hsElements[sum - arr[i]] -= 1;
                }
            }

            return lstResult;
        }
    }
}
