using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = "jesslookedliketimherbrother";
            string input = "jesher";
            HashSet<string> dictionary = new HashSet<string>()
            {
                "looked", "just", "like", "her", "brother", "jes","i"
            };

            string output = BestSplit(input, dictionary);

            Console.ReadLine();
        }

        private static string BestSplit(string sen, HashSet<string> dictionary)
        {
            ParseResult r = Split(sen, 0, dictionary);
            return r == null ? null : r.Parsed;
        }

        private static ParseResult Split(string sen, int start, HashSet<string> dictionary)
        {
            if (start >= sen.Length)
                return new ParseResult(0, "");

            int bestInvalid = int.MaxValue;
            string bestParsing = null;
            string partial = "";
            int index = start;

            while (index < sen.Length)
            {
                char c = sen[index];
                partial += c;
                int invalid = dictionary.Contains(partial) ? 0 : partial.Length;

                if (invalid < bestInvalid)
                {
                    ParseResult result = Split(sen, index + 1, dictionary);
                    if (invalid + result.Invalid < bestInvalid)
                    {
                        bestInvalid = invalid + result.Invalid;
                        bestParsing = partial + " " + result.Parsed;
                        if (bestInvalid == 0)
                            break;
                    }
                }

                index++;
            }

            return new ParseResult(bestInvalid, bestParsing);
        }

        public class ParseResult
        {
            public int Invalid { get; set; }
            public string Parsed { get; set; }

            public ParseResult(int inv, string p)
            {
                Invalid = inv;
                Parsed = p;
            }
        }
    }
}
