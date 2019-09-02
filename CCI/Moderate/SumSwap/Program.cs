using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumSwap
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arrA = { 4, 1, 2, 1, 1, 2 };
            //int[] arrB = { 3, 6, 3, 3 };

            int[] arrA = { 4, 2 };
            int[] arrB = { 3, 1 };

            var result = SumSwap(arrA, arrB);

            Console.ReadLine();
        }

        private static List<int> SumSwap(int[] arrA, int[] arrB)
        {
            int sumA = 0;
            int sumB = 0;

            List<int> lstResult = new List<int>();
            HashSet<int> hsArrA = new HashSet<int>();

            for (int i = 0; i < arrA.Length; i++)
            {
                sumA += arrA[i];
                hsArrA.Add(arrA[i]);
            }

            for (int i = 0; i < arrB.Length; i++)
            {
                sumB += arrB[i];
            }

            int requiredDiff = (sumA - sumB) / 2;

            for (int i = 0; i < arrB.Length; i++)
            {
                if (hsArrA.Contains(requiredDiff + arrB[i]))
                {
                    lstResult.Add(requiredDiff + arrB[i]);
                    lstResult.Add(arrB[i]);
                    break;
                }
            }

            return lstResult;
        }
    }
}
