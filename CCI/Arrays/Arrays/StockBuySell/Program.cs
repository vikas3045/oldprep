using System;
using System.Collections.Generic;

namespace StockBuySell
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 101, 100, 180, 260, 310, 40, 535, 695 };

            StockBuySell(arr);

            Console.ReadLine();
        }

        private static void StockBuySell(int[] price)
        {
            List<BuySellInterval> lstIntervals = new List<BuySellInterval>();
            int n = price.Length;
            int i = 0;
            while (i < n)
            {
                // Find Local Minima. Note that the limit is (n-2) as we are
                // comparing present element to the next element. 
                while ((i < n - 1) && (price[i + 1] <= price[i]))
                    i++;

                // If we reached the end, break as no further solution possible
                if (i == n - 1)
                    break;

                BuySellInterval e = new BuySellInterval();
                e.Buy = i++;
                // Store the index of minima


                // Find Local Maxima. Note that the limit is (n-1) as we are
                // comparing to previous element
                while ((i < n) && (price[i] >= price[i - 1]))
                    i++;

                // Store the index of maxima
                e.Sell = i - 1;
                lstIntervals.Add(e);
            }

            // print solution
            if (lstIntervals.Count == 0)
                Console.WriteLine("There is no day when buying the stock " + "will make profit");
            else
            {
                foreach (var interval in lstIntervals)
                {
                    Console.WriteLine("Buy on day: " + interval.Buy
                        + "        " + "Sell on day : " + interval.Sell);
                }
            }
        }

        class BuySellInterval
        {
            public int Buy { get; set; }
            public int Sell { get; set; }
        }
    }
}
