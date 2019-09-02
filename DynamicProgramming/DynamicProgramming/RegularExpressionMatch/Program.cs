using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            string pattern = "a**************************************************************************************";

            Dictionary<string, bool> dicMemo = new Dictionary<string, bool>();
            var result = IsMatch(str, pattern, ref dicMemo);

            Console.ReadLine();
        }

        private static bool IsMatch(string str, string pattern, ref Dictionary<string, bool> dicMemo)
        {
            if (str == pattern) return true;

            if (String.IsNullOrWhiteSpace(str) && String.IsNullOrWhiteSpace(pattern))
                return true;
            else if (String.IsNullOrWhiteSpace(pattern) || String.IsNullOrWhiteSpace(str))
                return false;

            int sLength = str.Length;
            int pLength = pattern.Length;

            var key = str + "|" + pattern;
            if (dicMemo.ContainsKey(key))
                return dicMemo[key];

            bool isMatch = false;

            if (str[sLength - 1] == pattern[pLength - 1] || pattern[pLength - 1] == '?')
            {
                isMatch = IsMatch(str.Substring(0, sLength - 1), pattern.Substring(0, pLength - 1), ref dicMemo);
            }
            else if (pattern[pLength - 1] == '*')
            {
                //Get to first non wildcard char
                int nonWildIndex = pLength - 1;
                while (nonWildIndex >= 0 && pattern[nonWildIndex] != '*' && pattern[nonWildIndex] != '?')
                    nonWildIndex--;

                if (nonWildIndex < 0)
                    return true;
                else
                {
                    string remainingPattern = pattern.Substring(0, pLength - (pLength - nonWildIndex) + 1);

                    isMatch = IsMatch(str.Substring(0, sLength - 1), pattern.Substring(0, remainingPattern.Length), ref dicMemo) ||
                        IsMatch(str, pattern.Substring(0, remainingPattern.Length - 1), ref dicMemo);
                }
            }
            else
                isMatch = false;

            dicMemo.Add(key, isMatch);
            return isMatch;
        }
    }
}
