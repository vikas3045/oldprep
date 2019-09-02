using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOf2s
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 25;

            var result = CountOf2s(n);

            Console.ReadLine();
        }

        private static int CountOf2s(int n)
        {
            int count = 0;
            for (int i = 2; i <= n; i++)
            {
                count += CountOf2sInNumber(i);
            }

            return count;
        }

        private static int CountOf2sInNumber(int n)
        {
            int count = 0;
            while (n > 0)
            {
                int digit = n % 10;
                if (digit == 2)
                    count++;

                n /= 10;
            }

            return count;
        }
    }
}
