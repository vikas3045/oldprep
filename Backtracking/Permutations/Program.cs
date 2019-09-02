using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dicLookUp = new Dictionary<int, int>();

            List<int> arr = new List<int>() { 1, 1, 4, 4 };

            var result = Permutations(arr);

            Console.ReadLine();
        }

        private static List<List<int>> Permutations(List<int> arr)
        {
            List<List<int>> lstResult = new List<List<int>>();

            Permutations(arr, 0, lstResult);

            return lstResult;
        }

        private static void Permutations(List<int> arr, int start, List<List<int>> lstResult)
        {
            if (start == arr.Count - 1)
            {
                var list = new List<int>(arr);
                lstResult.Add(list);
            }
            else
            {
                for (int i = start; i < arr.Count; i++)
                {
                    // check below conditions if specifically need unique permutations
                    if (!ContainsDuplicate(ref arr, start, i))
                    {
                        Swap(ref arr, start, i);
                        Permutations(arr, start + 1, lstResult);
                        Swap(ref arr, start, i);
                    }
                }
            }
        }

        private static void Swap(ref List<int> list, int a, int b)
        {
            int temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }

        private static bool ContainsDuplicate(ref List<int> arr, int start, int end)
        {
            for (int i = start; i <= end - 1; i++)
            {
                if (arr[i] == arr[end])
                    return true;
            }

            return false;
        }
    }
}
