using System;
using System.Collections.Generic;
using System.Text;

namespace IsPermutationOfPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Tact Coa";

            Console.WriteLine(IsPermutationOfPalindrome(input));
            Console.ReadLine();
        }

        private static bool IsPermutationOfPalindrome(string str)
        {
            Dictionary<char, int> dicStr = new Dictionary<char, int>();
            char[] charset = str.ToCharArray();

            for (int i = 0; i < charset.Length; i++)
            {
                if (Char.IsLetter(charset[i]))
                {
                    char lowercaseChar = Char.ToLower(charset[i]);
                    if (!dicStr.ContainsKey(lowercaseChar))
                        dicStr.Add(lowercaseChar, 1);
                    else
                        dicStr[lowercaseChar] += 1;
                }
            }

            int oddCount = 0;
            foreach (KeyValuePair<char, int> item in dicStr)
            {
                if (item.Value % 2 != 0)
                {
                    oddCount++;
                    if (oddCount > 1)
                        return false;
                }
            }
            return true;
        }
    }
}
