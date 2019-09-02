using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromePartioning
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "nitin";

            var result = PalindromePartioning(input);

            Console.ReadLine();
        }

        private static List<List<string>> PalindromePartioning(string str)
        {
            List<List<string>> lstResult = new List<List<string>>();
            List<string> currentPartition = new List<string>();

            GetPalindromePartioning(str, 0, currentPartition, lstResult);

            return lstResult;
        }

        private static void GetPalindromePartioning(string str, int curIndex, List<string> currentPartition, List<List<string>> lstResult)
        {
            if (curIndex >= str.Length)
            {
                lstResult.Add(currentPartition);
                return;
            }

            for (int i = curIndex; i < str.Length; i++)
            {
                List<string> subPartition = new List<string>(currentPartition);
                if (IsPalindrome(str, curIndex, i))
                {
                    subPartition.Add(str.Substring(curIndex, i - curIndex + 1));
                    GetPalindromePartioning(str, i + 1, subPartition, lstResult);
                }
            }
        }

        private static bool IsPalindrome(string str, int curIndex, int i)
        {
            int low = curIndex;
            int high = i;

            while (low < high)
            {
                if (str[low] != str[high])
                    return false;
                low++;
                high--;
            }

            return true;
        }
    }
}
