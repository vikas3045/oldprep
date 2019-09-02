using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintFence
{
    class Program
    {
        /// <problem>
        /// /Given a fence with n posts and k colors, find out the number of ways of painting the fence such that 
        /// at most 2 adjacent posts have the same color. Since answer can be large return it modulo 10^9 + 7.
        /// </problem>
        static void Main(string[] args)
        {
            int numberOfColours = 2;
            int numberOfPosts = 3;

            Console.WriteLine(WaysToPaintFence(numberOfPosts, numberOfColours));

            Console.ReadLine();
        }

        private static int WaysToPaintFence(int numberOfPosts, int numberOfColours)
        {
            if (numberOfPosts == 0) return 0;
            if (numberOfColours == 0) return 0;

            // same
            
        }
    }
}
