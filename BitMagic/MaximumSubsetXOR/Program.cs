using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSubsetXOR
{
    class Program
    {
        static void Main(string[] args)
        {
            //////////////////////////
            ///////////////////////////
            // NOT CORRECT


            int[] arr = { 8, 1, 2, 12, 7, 6 };

            //Console.Write(1 ^ 2 ^ 12);

            Console.WriteLine(MaximumSubsetXOR(arr, 0));

            Console.ReadLine();
        }

        private static int MaximumSubsetXOR(int[] arr, int curPos)
        {
            if (curPos == arr.Length - 1)
                return 0;
            //if (arr.Length - curPos == 2)
            //    return arr[curPos] ^ arr[curPos + 1];

            int maxIncluding = arr[curPos] ^ MaximumSubsetXOR(arr, curPos + 1);
            int maxExcluding = MaximumSubsetXOR(arr, curPos + 1);

            return Math.Max(maxIncluding, maxExcluding);
        }
    }
}
