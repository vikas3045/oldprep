using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masseuse
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 30, 15, 60, 75, 45, 15, 45 };

            var result = HighestBookedMinutes(arr);

            Console.ReadLine();
        }

        private static int HighestBookedMinutes(int[] arr)
        {
            Dictionary<int, int> dicMemo = new Dictionary<int, int>();
            return HighestBookedMinutes(arr, 0, dicMemo);
        }

        private static int HighestBookedMinutes(int[] arr, int curPos, Dictionary<int, int> dicMemo)
        {
            if (curPos >= arr.Length)
                return 0;

            if (dicMemo.ContainsKey(curPos))
                return dicMemo[curPos];

            // include current
            int incl = arr[curPos] + HighestBookedMinutes(arr, curPos + 2, dicMemo);

            // exclude current
            int excl = HighestBookedMinutes(arr, curPos + 1, dicMemo);

            int result = Math.Max(incl, excl);
            dicMemo.Add(curPos, result);

            return result;
        }
    }
}
