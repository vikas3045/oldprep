using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromicSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "abc";

            var result = CountOfPalindromicSubstrings(str);

            Console.ReadLine();
        }

        private static int CountOfPalindromicSubstrings(string str)
        {
            return CountOfPalindromicSubstrings(str, 0, str.Length - 1);
        }

        private static int CountOfPalindromicSubstrings(string str, int start, int end)
        {
            if (start > end)
                return 0;

            int totalCount = 0;
            if (IsPalindrome(str, start, end))
                totalCount += 1;

            totalCount += CountOfPalindromicSubstrings(str, start + 1, end) + CountOfPalindromicSubstrings(str, start, end - 1) -
                CountOfPalindromicSubstrings(str, start + 1, end - 1);

            return totalCount;
        }

        private static bool IsPalindrome(string str, int start, int end)
        {
            if (end - start <= 0) return true;

            while (start < end)
            {
                if (str[start] != str[end])
                    return false;
                start++;
                end--;
            }

            return true;
        }
    }
}
