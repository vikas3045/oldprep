using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestWord
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arr = new List<string>()
            {
                "cat", "banana", "dog", "nana", "walk", "er", "dogwalker"
            };

            var result = GetLongestWord(arr);

            Console.ReadLine();
        }

        private static string GetLongestWord(List<string> arr)
        {
            HashSet<string> hsLookup = new HashSet<string>();
            foreach (var s in arr)
            {
                hsLookup.Add(s);
            }

            arr = arr.OrderByDescending(s => s.Length).ToList();

            foreach (var s in arr)
            {
                if (CanBeBuild(s, true, hsLookup))
                    return s;
            }

            return null;
        }

        private static bool CanBeBuild(string s, bool isOriginal, HashSet<string> hsLookup)
        {
            if (String.IsNullOrWhiteSpace(s))
                return true;

            if (!isOriginal)
                return hsLookup.Contains(s);

            for (int i = 0; i < s.Length; i++)
            {
                string left = s.Substring(0, i + 1);
                string right = s.Substring(i + 1);
                if (hsLookup.Contains(left) && CanBeBuild(right, false, hsLookup))
                    return true;
            }

            return false;
        }
    }
}
