using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rand7FromRand5
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(Rand7FromRand5());

            Console.ReadLine();
        }

        private static int Rand7FromRand5()
        {
            while (true)
            {
                int num = 5 * Rand5() + Rand5();
                if (num < 21)
                    return num % 7;
            }
        }

        private static int Rand5()
        {
            Random random = new Random();
            return random.Next(5);
        }
    }
}
