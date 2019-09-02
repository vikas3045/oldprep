using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivingBoard
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public HashSet<int> AllLengths(int k, int shorter, int longer, int totalLength)
        {
            HashSet<int> hsLengths = new HashSet<int>();
            GetAllLengths(k, shorter, longer, 0, hsLengths);
            return hsLengths;
        }

        private void GetAllLengths(int k, int shorter, int longer, int totalLength, HashSet<int> hsLengths)
        {
            if (k == 0)
            {
                hsLengths.Add(totalLength);
                return;
            }

            // pick shorter
            GetAllLengths(k - 1, shorter, longer, totalLength + shorter, hsLengths);

            // pick longer
            GetAllLengths(k - 1, shorter, longer, totalLength + longer, hsLengths);
        }
    }
}
