using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveAdjacentDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = "geeksforgeek";
            Console.WriteLine(RemoveAdjacentDuplicates(inputStr));

            Console.ReadLine();
        }

        private static string RemoveAdjacentDuplicates(string inputStr)
        {
            StringBuilder sbResult = new StringBuilder();

            for (int i = 0; i < inputStr.Length - 1; i++)
            {
                if (inputStr[i] != inputStr[i + 1])
                    sbResult.Append(inputStr[i]);

                //skip adjacent duplicates
                while (i < inputStr.Length - 1 && inputStr[i] == inputStr[i + 1])
                    i++;
            }

            if (inputStr[inputStr.Length - 2] != inputStr[inputStr.Length - 1])
                sbResult.Append(inputStr[inputStr.Length - 1]);

            string result = sbResult.ToString();

            if (result.Length != inputStr.Length)
                return RemoveAdjacentDuplicates(result);
            else
                return result;
        }
    }
}
