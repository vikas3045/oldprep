using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialZeros
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 19;

            //var result = GetFactorialZerosCount(n);
            var result = GetFactorialZerosCountEff(n);

            Console.ReadLine();
        }

        private static int GetFactorialZerosCount(int n)
        {
            int count = 0;
            for (int i = 2; i < n; i++)
            {
                count += GetFactorsOf5(i);
            }

            return count;
        }

        private static int GetFactorsOf5(int n)
        {
            int count = 0;
            while (n % 5 == 0)
            {
                count++;
                n /= 5;
            }

            return count;
        }

        private static int GetFactorialZerosCountEff(int num)
        {
            if (num < 0)
                return -1;

            int count = 0;           

            for (int i = 5; num / i > 0; i *= 5)
            {
                count += num / i;
            }

            return count;
        }
    }
}
