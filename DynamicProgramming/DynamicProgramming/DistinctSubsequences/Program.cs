using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctSubsequences
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "rabbbit";
            string T = "rabbit";

            Dictionary<int, int> dicMemo = new Dictionary<int, int>();
            Console.WriteLine(DistinctSubsequences(S, T, dicMemo));

            Console.ReadLine();
        }

        private static int DistinctSubsequences(string s, string t, Dictionary<int, int> dicMemo)
        {
            int sLength = s.Length;
            int tLength = t.Length;

            // Base conditions
            if (sLength < tLength)
                return 0;

            if (String.IsNullOrWhiteSpace(s) || String.IsNullOrWhiteSpace(t))
                return 1;


            var key = s + "|" + t;
            if (dicMemo.ContainsKey(key.GetHashCode()))
                return dicMemo[key.GetHashCode()];

            int result = 0;

            if (s[sLength - 1] == t[tLength - 1])
            {
                result = DistinctSubsequences(s.Substring(0, sLength - 1), t.Substring(0, tLength - 1), dicMemo) +
                    DistinctSubsequences(s.Substring(0, sLength - 1), t, dicMemo);
            }
            else
                result = DistinctSubsequences(s.Substring(0, sLength - 1), t, dicMemo);

            dicMemo.Add(key.GetHashCode(), result);

            return result;
        }
    }
}
