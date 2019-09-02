using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinJumps
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 1, 3, 6, 3, 2, 3, 6, 8, 9, 5 };
            int[] arr = { 1, 3, 6, 3, 2 };

            var result = MinJumps(arr, 0, arr.Length - 1);

            Console.ReadLine();
        }

        private static int MinJumps(int[] arr, int start, int end)
        {
            if (start == end) return 0;

            if (arr[start] == 0) return int.MaxValue;

            int minJumps = int.MaxValue;
            for (int i = start + 1; i <= end && i <= start + arr[start]; i++)
            {
                int jumps = MinJumps(arr, i, end);
                minJumps = Math.Min(minJumps, jumps) + 1;
            }

            return minJumps;
        }
    }
}
