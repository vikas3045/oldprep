using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSwapper
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 15;

            Swap(a, b);

            Console.ReadLine();
        }

        private static void Swap(int a, int b)
        {
            a = a - b;
            b = b + a;
            a = b - a;

            /// or
            /// a = a ^ b;
            /// b = a ^ b;
            /// a = a ^ b;
        }
    }
}
