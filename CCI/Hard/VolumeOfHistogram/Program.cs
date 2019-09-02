using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumeOfHistogram
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 0, 0, 4, 0, 0, 6, 0, 0, 3, 0, 5, 0, 1, 0, 0, 0 };
            int[] arr = { 3, 0, 0, 2, 0, 4, 2 };

            var result = MaxWaterCapacity(arr);

            Console.ReadLine();
        }

        private static int MaxWaterCapacity(int[] arr)
        {
            int[] LMax = new int[arr.Length];
            int[] RMax = new int[arr.Length];

            int lMax = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                LMax[i] = lMax;
                lMax = Math.Max(lMax, arr[i]);
            }

            int rMax = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                RMax[i] = rMax;
                rMax = Math.Max(rMax, arr[i]);
            }

            int totalVol = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int maxPossibleHeight = Math.Min(LMax[i], RMax[i]);
                int actualHeight = maxPossibleHeight - arr[i];
                if (actualHeight > 0)
                    totalVol += actualHeight;
            }

            return totalVol;
        }
    }
}
