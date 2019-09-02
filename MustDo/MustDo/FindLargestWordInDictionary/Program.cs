using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindLargestWordInDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> dic = new List<string>()
            {
                "ale", "apple", "monkey", "plea"
            };

            string str = "abpcplea";

            Console.WriteLine(FindLargestWordInDictionary(str, dic));

            Console.ReadLine();
        }

        private static string FindLargestWordInDictionary(string str, List<string> dic)
        {
            string result = string.Empty;

            foreach (var word in dic)
            {
                if (IsMatched(str, word) && result.Length < word.Length)
                    result = word;
            }

            return result;
        }

        private static bool IsMatched(string str, string word)
        {
            int sIndex = 0;
            int wIndex = 0;
            int matchedChars = 0;

            while (sIndex < str.Length && wIndex < word.Length)
            {
                if (str[sIndex] == word[wIndex])
                {
                    matchedChars++;
                    sIndex++;
                    wIndex++;
                }
                else
                {
                    sIndex++;
                }
            }

            return matchedChars == word.Length;
        }
    }
}
