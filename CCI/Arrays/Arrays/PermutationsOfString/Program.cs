using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationsOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            String inputStr = "ABC";
            PermutationsOfString(inputStr.ToCharArray(), 0, inputStr.Length - 1);

            Console.ReadLine();
        }

        private static void PermutationsOfString(char[] inputStr, int left, int right)
        {
            if (left == right)
                Console.WriteLine(inputStr);
            else
            {
                for (int i = left; i <= right; i++)
                {
                    Swap(inputStr, left, i);
                    PermutationsOfString(inputStr, left + 1, right);
                    Swap(inputStr, left, i);
                }
            }
        }

        private static void Swap(char[] inputStr, int i, int j)
        {
            char temp;
            temp = inputStr[i];
            inputStr[i] = inputStr[j];
            inputStr[j] = temp;
        }
    }
}
