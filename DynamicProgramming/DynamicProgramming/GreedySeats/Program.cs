using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedySeats
{
    class Program
    {
        static void Main(string[] args)
        {
            string seatingArrangement = "....x..xx...x..";
            var hopsRequired = Seats(seatingArrangement);

            Console.ReadLine();
        }

        public static int Seats(string A)
        {
            int left = A.IndexOf('x');
            int right = A.LastIndexOf('x');

            long jumps = 0;
            int mod = 10000003;

            while (left < right)
            {
                int jump = 0;
                for (int i = left + 1; i < right; i++)
                {
                    if (A[i] == 'x')
                    {
                        left = i;
                        jumps += jump;
                    }
                    else
                        jump++;
                }

                jump = 0;

                for (int i = right - 1; i > left; i--)
                {
                    if (A[i] == 'x')
                    {
                        right = i;
                        jumps += jump;
                    }
                    else
                        jump++;
                }
            }

            return (int)jumps % mod;
        }
    }
}
