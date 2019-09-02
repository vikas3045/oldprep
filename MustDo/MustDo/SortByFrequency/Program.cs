using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortByFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 2, 4, 5, 12, 2, 3, 3, 3, 12 };
            SortByFrequency(arr);

            Console.ReadLine();
        }

        private static void SortByFrequency(int[] arr)
        {
            Dictionary<int, int> mapCount = new Dictionary<int, int>();

            foreach (var ele in arr)
            {
                if (!mapCount.ContainsKey(ele))
                    mapCount.Add(ele, 1);
                else
                    mapCount[ele] += 1;
            }

            SortedDictionary<int, List<int>> sortedMap = new SortedDictionary<int, List<int>>();

            foreach (var pair in mapCount)
            {
                if (!sortedMap.ContainsKey(pair.Value))
                {
                    sortedMap.Add(pair.Value, new List<int>() { pair.Key });
                }
                else
                {
                    var lst = sortedMap[pair.Value];
                    lst.Add(pair.Key);
                    sortedMap[pair.Value] = lst;
                }
            }

            List<int> nArr = new List<int>();
            foreach (var pair in sortedMap)
            {
                int freq = pair.Key;
                foreach (var element in pair.Value)
                {
                    for (int i = 0; i < freq; i++)
                        nArr.Add(element);
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = nArr[i];
            }
        }
    }
}
