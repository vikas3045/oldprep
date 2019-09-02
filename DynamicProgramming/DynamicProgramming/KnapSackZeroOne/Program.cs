using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapSackZeroOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] val = new int[] { 60, 100, 120 };
            int[] wt = new int[] { 10, 20, 30 };
            int W = 50;
            int n = val.Length;

            Console.WriteLine(KnapSackZeroOne(W, wt, val, n));

            Console.ReadLine();
        }

        private static int KnapSackZeroOne(int w, int[] wt, int[] val, int n)
        {
            if (n == 0 || w == 0)
                return 0;

            if (wt[n - 1] > w)
                KnapSackZeroOne(w, wt, val, n - 1);

            int incl = val[n - 1] + KnapSackZeroOne(w - wt[n - 1], wt, val, n - 1);
            int excl = KnapSackZeroOne(w, wt, val, n - 1);

            return Math.Max(incl, excl);
        }

        public static int KnapSackZeroOneDP(int w, int[] wt, int[] val, int n)
        {
            int[,] memo = new int[val.Length + 1, wt.Length + 1];

            memo[0, 0] = 0;

            for (int i = 0; i <= val.Length; i++)
            {
                for (int j = 0; j < w; i++)
                {
                    if (i == 0 || w == 0)
                        memo[i, w] = 0;
                    else if (wt[i - 1] <= w)
                    {
                        int incl = val[i - 1] + memo[i - 1, w - wt[i - 1]];
                        int excl = memo[i - 1, w];
                        memo[i, w] = Math.Max(incl, excl);
                    }
                    else
                        memo[i, w] = memo[i - 1, w];
                }
            }

            return memo[n, w];
        }
    }
}
