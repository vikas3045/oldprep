using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "palse";
            string b = "false";

            int result = LCS(a, b);

            Console.ReadLine();
        }

        private static int LCS(string a, string b)
        {
            int aLength = a.Length;
            int bLength = b.Length;

            int[,] memo = new int[aLength + 1, bLength + 1];

            for (int i = 0; i < aLength; i++)
            {
                for (int j = 0; j < bLength; j++)
                {
                    if (a[i] == b[j])
                    {
                        memo[i + 1, j + 1] = 1 + memo[i, j];
                    }
                    else
                    {
                        memo[i + 1, j + 1] = Math.Max(memo[i + 1, j], memo[i, j + 1]);
                    }
                }
            }

            return memo[aLength, bLength];
        }
    }
}
