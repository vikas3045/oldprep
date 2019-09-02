using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WordBreak("ilikesamsung"));

            Console.ReadLine();
        }

        private static bool WordBreak(string word)
        {
            if (word.Length == 0)
                return true;

            for (int i = 0; i < word.Length; i++)
            {
                var prefix = word.Substring(0, i + 1);

                if (IsPresentInDictionary(prefix) && WordBreak(word.Substring(i + 1)))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsPresentInDictionary(string prefix)
        {
            string[] dictionary = {"mobile","samsung","sam","sung",
                            "man","mango","icecream","and",
                             "go","i","like","ice","cream"};

            return dictionary.Contains(prefix);
        }
    }
}
