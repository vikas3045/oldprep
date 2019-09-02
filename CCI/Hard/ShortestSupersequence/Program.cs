using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestSupersequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] shorter = { 1, 5, 9 };
            int[] longer = { 7, 5, 9, 0, 2, 1, 3, 5, 7, 9, 1, 1, 5, 8, 8, 9, 7 };

            var result = ShortestSupersequence(longer, shorter);

            Console.ReadLine();
        }

        private static List<int> ShortestSupersequence(int[] longer, int[] shorter)
        {
            HashSet<int> hsShorter = new HashSet<int>();
            Dictionary<int, int> dicLookup = new Dictionary<int, int>();

            foreach (int i in shorter)
                hsShorter.Add(i);

            int index = 0;
            List<int> lstIndices = new List<int>();
            while (index < longer.Length)
            {
                if (hsShorter.Contains(longer[index]))
                {
                    if (!dicLookup.ContainsKey(longer[index]))
                        dicLookup.Add(longer[index], index);
                }

                index++;
            }

            if (dicLookup.Count < hsShorter.Count)
                return null;

            foreach (var pair in dicLookup)
            {

            }
        }
    }
}
