using System;
using System.Collections.Generic;

namespace LongestPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            String inputStr = "forgeeksskeegfor";

            Dictionary<string, string> dicMemo = new Dictionary<string, string>();
            Console.WriteLine(LongestPalindrome(inputStr, dicMemo));

            Console.ReadLine();
        }

        private static string LongestPalindrome(string inputStr, Dictionary<string, string> dicMemo)
        {
            if (dicMemo.ContainsKey(inputStr))
                return dicMemo[inputStr];

            string result = string.Empty;
            if (IsPalindrome(inputStr))
                result = inputStr;
            else
            {
                int inputLength = inputStr.Length;

                string longestPalindromeIncludingFirstChar = LongestPalindrome(inputStr.Substring(0, inputLength - 1), dicMemo);
                string longestPalindromeExcludingFirstChar = LongestPalindrome(inputStr.Substring(1), dicMemo);

                if (longestPalindromeIncludingFirstChar.Length > longestPalindromeExcludingFirstChar.Length)
                    result = longestPalindromeIncludingFirstChar;
                else
                    result = longestPalindromeExcludingFirstChar;
            }

            dicMemo.Add(inputStr, result);
            return result;
        }

        private static bool IsPalindrome(string inputStr)
        {
            if (String.IsNullOrWhiteSpace(inputStr) || inputStr.Length == 1)
                return true;

            for (int i = 0; i < inputStr.Length / 2; i++)
            {
                if (inputStr[i] != inputStr[(inputStr.Length - 1) - i])
                    return false;
            }

            return true;
        }
    }
}
