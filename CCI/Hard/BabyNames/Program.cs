using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyNames
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mapCount = new Dictionary<string, int>()
            {
                {"John", 15},
                {"Jon", 12},
                {"Chris", 13},
                {"Kris", 4},
                {"Christopher", 19}
            };

            List<List<string>> lstSynonyms = new List<List<string>>()
            {
                {new List<string>(){"Jon", "John" } },
                {new List<string>(){"John", "Johnny" } },
                {new List<string>(){"Chris", "Kris" } },
                {new List<string>(){"Chris", "Christopher" } }
            };

            var result = FindActualFrequency(mapCount, lstSynonyms);

            Console.ReadLine();
        }

        private static Dictionary<string, int> FindActualFrequency(Dictionary<string, int> mapCount, List<List<string>> lstSynonyms)
        {
            Dictionary<string, int> mapResult = new Dictionary<string, int>();
            HashSet<string> hsVisited = new HashSet<string>();

            foreach (var pair in mapCount)
            {
                GetNameFrequency(pair, pair.Key, mapCount, lstSynonyms, hsVisited, mapResult);
            }

            return mapResult;
        }

        private static void GetNameFrequency(KeyValuePair<string, int> currentName, string syn, Dictionary<string, int> mapCount, List<List<string>> lstSynonyms, HashSet<string> hsVisited, Dictionary<string, int> mapResult)
        {
            if (hsVisited.Contains(syn))
                return;

            hsVisited.Add(syn);

            int currentCount = 0;
            if (mapCount.ContainsKey(syn))
                currentCount = mapCount[syn];

            if (!mapResult.ContainsKey(currentName.Key))
                mapResult.Add(currentName.Key, currentCount);
            else
                mapResult[currentName.Key] += currentCount;

            foreach (var s in GetSynonyms(currentName.Key, lstSynonyms))
            {
                GetNameFrequency(currentName, s, mapCount, lstSynonyms, hsVisited, mapResult);
            }            
        }

        private static List<string> GetSynonyms(string name, List<List<string>> lstSynonyms)
        {
            List<string> lstResult = new List<string>();
            for (int r = 0; r < lstSynonyms.Count; r++)
            {
                if (name == lstSynonyms[r][0])
                    lstResult.Add(lstSynonyms[r][1]);
                else if (name == (lstSynonyms[r][1]))
                    lstResult.Add(lstSynonyms[r][0]);
            }

            return lstResult;
        }
    }
}
