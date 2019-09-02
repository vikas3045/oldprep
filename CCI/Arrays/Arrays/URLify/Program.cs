using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLify
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Mr John Smith            ";
            int trueLength = 13;
            Console.WriteLine("input: " + input);
            char[] inputCharset = input.ToCharArray();

            URLify(inputCharset, trueLength);
            string s = new string(inputCharset);
            Console.WriteLine("output: " + s);

            Console.ReadLine();
        }

        private static void URLify(char[] input, int trueLength)
        {
            int spaceCount = 0;
            for (int i = 0; i < trueLength; i++)
            {
                if (input[i] == ' ')
                    spaceCount++;
            }
            int index = trueLength + spaceCount * 2;
            if (trueLength < input.Length)
                input[index] = '\0';
            for (int i = trueLength - 1; i >= 0; i--)
            {
                if (input[i] == ' ')
                {
                    input[index - 1] = '0';
                    input[index - 2] = '2';
                    input[index - 3] = '%';
                    index -= 3;
                }
                else
                {
                    input[index - 1] = input[i];
                    index--;
                }
            }
        }
    }
}
