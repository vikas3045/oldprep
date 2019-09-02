using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static void Shuffle(int[] cards)
        {
            Random random = new Random();
            for (int i = 0; i < cards.Length; i++)
            {
                int k = random.Next(0, i);
                int temp = cards[k];
                cards[k] = cards[i];
                cards[i] = temp;
            }
        }
    }
}
