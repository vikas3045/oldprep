using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMagic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number in decimal system");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(PositionOfRightmostSetBit(number));

            Console.ReadLine();
        }

        private static int PositionOfRightmostSetBit(int number)
        {
            var binaryNumber = DecimalToBinary.ConvertToBinary(number);

            for (int i = binaryNumber.Length - 1; i >= 0; i--)
            {
                if (binaryNumber[i] == '1')
                    return binaryNumber.Length - i;
            }

            return -1;
        }
    }
}
