using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMagic
{
    public class DecimalToBinary
    {
        static void Main(string[] args)
        {
            //int number = 15;

            //Convert.ToString(number, 2);
            Console.WriteLine("Enter a number in decimal system: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(ConvertToBinary(number));

            Console.WriteLine();

            Console.WriteLine(Convert.ToString(number, 2));

            Console.ReadLine();
        }

        public static string ConvertToBinary(int number)
        {
            int quot;
            string remainder = "";
            while (number >= 1)
            {
                // Find the digit for current place
                remainder += (number % 2).ToString();

                // Get the integral part for further processing
                quot = number / 2;

                number = quot;
            }

            // Reversing the number thus generated (coz we have generated digits from right to left but we read
            // it as left to right)
            string bin = "";
            for (int i = remainder.Length - 1; i >= 0; i--)
            {
                bin += remainder[i];
            }

            return bin;
        }
    }
}
