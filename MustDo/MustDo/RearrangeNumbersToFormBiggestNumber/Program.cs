using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RearrangeNumbersToFormBiggestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 54, 546, 548, 60 };

            int[] resultArr = RearrangeNumbersToFormBiggestNumber(arr);

            for (int i = 0; i < resultArr.Length; i++)
            {
                Console.Write(resultArr[i]);
            }

            Console.ReadLine();
        }

        private static int[] RearrangeNumbersToFormBiggestNumber(int[] arr)
        {
            Array.Sort(arr, CustomComparer);

            return arr;
        }

        private static int CustomComparer(int a, int b)
        {
            string result1 = a.ToString() + b.ToString();
            string result2 = b.ToString() + a.ToString();

            return String.Compare(result2, result1);
        }
    }
}
