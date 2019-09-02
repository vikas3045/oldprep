using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddWithoutPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = AddWithoutPlus(759, 674);

            Console.ReadLine();
        }

        private static int AddWithoutPlus(int a, int b)
        {
            if (b == 0)
                return a;

            // Add without carrying
            int sum = a ^ b;

            // Carry but don't add
            int carry = (a & b) << 1;
            return AddWithoutPlus(sum, carry);
        }
    }
}
