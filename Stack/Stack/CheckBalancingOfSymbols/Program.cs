using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stack;

namespace CheckBalancingOfSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            if (IsValidSymbolPattern("((A+B)+(C+D))"))
                Console.WriteLine("Symbol pattern is valid");
            else
                Console.WriteLine("Symbol pattern is invalid");

            Console.ReadLine();
        }

        private static bool IsValidSymbolPattern(string symbol)
        {
            if (String.IsNullOrWhiteSpace(symbol))
                return true;
            else
            {
                for(int i = 0; i < symbol.Length; i++)
                {
                    if(symbol.CharA)
                }
            }
        }
    }
}
