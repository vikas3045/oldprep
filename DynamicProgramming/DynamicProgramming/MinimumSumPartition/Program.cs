using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSumPartition
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = { 1, 6, 11, 5 };
            Dictionary<string, int> dicMemo = new Dictionary<string, int>();

            Console.WriteLine(MinimumSumPartition(inputArr, inputArr.Length - 1, 0, 0, dicMemo));

            Console.ReadLine();
        }

        private static int MinimumSumPartition(int[] inputArr, int i, int S1, int S2, Dictionary<string, int> dicMemo)
        {
            if (i < 0)
                return Math.Abs(S1 - S2);

            if (i >= inputArr.Length)
                throw new Exception("Invalid index");

            string key = i + "|" + S1 + "|" + S2;

            if (dicMemo.ContainsKey(key))
                return dicMemo[key];

            int incl = MinimumSumPartition(inputArr, i - 1, S1 + inputArr[i], S2, dicMemo);
            int excl = MinimumSumPartition(inputArr, i - 1, S1, S2 + inputArr[i], dicMemo);

            int result = Math.Min(incl, excl);
            dicMemo.Add(key, result);
            return result;
        }
    }
}
