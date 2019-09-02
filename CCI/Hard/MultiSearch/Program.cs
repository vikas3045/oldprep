using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string b = "mississippi";
            string[] T = { "is", "sis", "miss", "ppi", "i", "hi" };

            Dictionary<string, List<int>> result = MultiSearch(b, T);

            Console.ReadLine();
        }

        private static Dictionary<string, List<int>> MultiSearch(string b, string[] strArr)
        {
            Dictionary<string, List<int>> lstResult = new Dictionary<string, List<int>>();

            foreach (string s in strArr)
            {
                List<int> lstIndices = GetSearchResult(s, b);
                lstResult.Add(s, lstIndices);
            }

            return lstResult;
        }

        private static List<int> GetSearchResult(string s, string b)
        {
            List<int> lstIndices = new List<int>();

            int i = 0;
            while (i < b.Length)
            {
                var index = b.IndexOf(s, i);
                if (index != -1)
                {
                    lstIndices.Add(index);
                    i = index + s.Length;
                }
                else
                {
                    i++;
                }
            }


            return lstIndices;
        }
    }
}
