using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Change
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = { 1, 2, 3 };
            int amount = 4;

            Console.WriteLine(WaysToMakeChange(coins, amount, coins.Length - 1));

            Console.ReadLine();
        }

        private static int WaysToMakeChange(int[] coins, int amount, int curPos)
        {
            if (amount == 0)
                return 1;
            else if (amount < 0)
                return 0;

            if (curPos < 0)
                return 0;

            if (coins[curPos] > amount)
                return WaysToMakeChange(coins, amount, curPos - 1);
            else
                return WaysToMakeChange(coins, amount - coins[curPos], curPos) +
                    WaysToMakeChange(coins, amount, curPos - 1);
        }
    }
}
