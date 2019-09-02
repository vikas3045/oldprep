using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersAndNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> arr = new List<char>() { 'a', 'b', '1', '8', 'f', '2', '0' };

            // Brute force approach
            //List<char> result = FindLongestSubArrayWithEqualLettersAndNumbers(arr);

            // Efficient approach
            List<char> result1 = FindLongestSubArray(arr);

            Console.ReadLine();
        }

        private static List<char> FindLongestSubArray(List<char> arr)
        {
            List<int> deltas = ComputeDeltaArray(arr);

            List<int> match = FindLongestMatch(deltas);

            return ExtractSubArray(arr, match[0] + 1, match[1]);
        }

        private static List<int> ComputeDeltaArray(List<char> arr)
        {
            List<int> deltas = new List<int>();
            int delta = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                if (Char.IsLetter(arr[i]))
                    delta++;
                else if (Char.IsDigit(arr[i]))
                    delta--;

                deltas.Add(delta);
            }

            return deltas;
        }

        private static List<int> FindLongestMatch(List<int> deltas)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, -1);
            List<int> max = new List<int>(2) { 0, 0 };

            for (int i = 0; i < deltas.Count; i++)
            {
                if (!map.ContainsKey(deltas[i]))
                    map.Add(deltas[i], i);
                else
                {
                    int match = map[deltas[i]];
                    int distance = i - match;
                    int longest = max[1] - max[0];
                    if (distance > longest)
                    {
                        max[1] = i;
                        max[0] = match;
                    }
                }
            }

            return max;
        }

        private static List<char> FindLongestSubArrayWithEqualLettersAndNumbers(List<char> arr)
        {
            for (int len = arr.Count; len > 1; len--)
            {
                for (int i = 0; i <= arr.Count - len; i++)
                {
                    if (HasEqualLettersNumbers(arr, i, i + len - 1))
                    {
                        return ExtractSubArray(arr, i, i + len - 1);
                    }
                }
            }

            return null;
        }

        private static List<char> ExtractSubArray(List<char> arr, int start, int end)
        {
            List<char> lstResult = new List<char>();
            for (int i = start; i <= end; i++)
            {
                lstResult.Add(arr[i]);
            }

            return lstResult;
        }

        private static bool HasEqualLettersNumbers(List<char> arr, int start, int end)
        {
            int counter = 0;
            for (int i = start; i <= end; i++)
            {
                if (Char.IsLetter(arr[i]))
                    counter++;
                else if (Char.IsDigit(arr[i]))
                    counter--;
            }

            return counter == 0;
        }
    }
}
