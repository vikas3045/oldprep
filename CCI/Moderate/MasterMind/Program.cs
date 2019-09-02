using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            string sol = "RGBY";
            string guess = "GGRR";

            var result = GetResult(sol, guess);

            Console.ReadLine();
        }

        private static Result GetResult(string sol, string guess)
        {
            Result result = new Result();
            HashSet<char> hsHits = GetHits(sol, guess, result);
            GetPseudoHits(sol, guess, result, hsHits);
            return result;
        }

        private static void GetPseudoHits(string sol, string guess, Result result, HashSet<char> hsHits)
        {
            HashSet<char> hsPHits = new HashSet<char>();
            foreach (char c in guess)
            {
                if (!hsHits.Contains(c) && sol.IndexOf(c) != -1)
                    hsPHits.Add(c);
            }

            result.PseudoHits = hsPHits.Count;
        }

        private static HashSet<char> GetHits(string sol, string guess, Result result)
        {
            HashSet<char> hsHits = new HashSet<char>();

            for (int i = 0; i < sol.Length - 1; i++)
            {
                if (sol[i] == guess[i])
                {
                    result.Hits += 1;
                    hsHits.Add(sol[i]);
                }
            }

            return hsHits;
        }

        public class Result
        {
            public int Hits { get; set; }
            public int PseudoHits { get; set; }
        }
    }
}
