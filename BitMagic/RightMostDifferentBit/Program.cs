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
            Console.WriteLine("Enter number 1 in decimal system");
            int numberA = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number 2 in decimal system");
            int numberB = int.Parse(Console.ReadLine());

            Console.WriteLine(RightMostDifferent(numberA, numberB));

            Console.ReadLine();
        }

        private static int RightMostDifferent(int numberA, int numberB)
        {
            return PositionOfRightmostSetBit(numberA ^ numberB);
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
