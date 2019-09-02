using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "aabab";
            string str = "catcatgocatgo";

            Console.WriteLine(DoesMatch(str, pattern));

            Console.ReadLine();
        }

        private static bool DoesMatch(string str, string pattern)
        {
            if (pattern.Length == 0)
                return str.Length == 0;

            char mainChar = pattern[0];
            char altChar = mainChar == 'a' ? 'b' : 'a';
            int size = str.Length;

            int countOfMain = CountOf(pattern, mainChar);
            int countOfAlt = pattern.Length - countOfMain;
            int firstAlt = pattern.IndexOf(altChar);
            int maxMainSize = size / countOfMain;

            for (int mainSize = 0; mainSize <= maxMainSize; mainSize++)
            {
                string first = str.Substring(0, mainSize);
                int remainingLength = size - (mainSize * countOfMain);

                if (countOfAlt == 0 || remainingLength % countOfAlt == 0)
                {
                    int altIndex = firstAlt * mainSize;
                    int altSize = countOfAlt == 0 ? 0 : remainingLength / countOfAlt;
                    string second = countOfAlt == 0 ? "" : str.Substring(altIndex, altSize);

                    string cand = BuildFromPattern(pattern, first, second);
                    if (cand.Equals(str))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static string BuildFromPattern(string pattern, string main, string alt)
        {
            StringBuilder sb = new StringBuilder();
            char first = pattern[0];
            foreach (char c in pattern)
            {
                if (c == first)
                    sb.Append(main);
                else
                    sb.Append(alt);
            }

            return sb.ToString();
        }

        private static int CountOf(string pattern, char c)
        {
            int count = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == c)
                    count++;
            }

            return count;
        }
    }
}
