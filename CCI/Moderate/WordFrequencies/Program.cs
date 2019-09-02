using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequencies
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] book = { "ram", "Ram", "Allen" };
            string word = "allen";

            var result = GetFrequency(word, book);

            Console.ReadLine();
        }

        public static int GetFrequency(string word, string[] book)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (var str in book)
            {
                var key = str.Trim().ToLower();
                if (!map.ContainsKey(key))
                    map.Add(key, 1);
                else
                    map[key] += 1;
            }

            if (!map.ContainsKey(word.Trim().ToLower()))
                return 0;

            return map[word.Trim().ToLower()];
        }
    }
}
