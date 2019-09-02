using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorityElement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //int[] arr = { 1, 2, 5, 9, 5, 5, 5 };
            int[] arr = { 1, 9, 5, 9, 5, 5, 5, 9, 9, 9, 9 };

            var result = MajorityElement(arr);

            Console.ReadLine();
        }

        public static int MajorityElement(int[] arr)
        {
            int candidate = GetCandidate(arr);
            return Validate(arr, candidate) ? candidate : -1;
        }

        public static bool Validate(int[] arr, int majority)
        {
            int count = 0;
            foreach (var n in arr)
            {
                if (n == majority)
                    count++;
            }

            return count > arr.Length / 2;
        }

        private static int GetCandidate(int[] arr)
        {
            int majorityElement = 0;
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (count == 0)
                    majorityElement = arr[i];

                if (arr[i] == majorityElement)
                    count++;
                else
                    count--;
            }

            return majorityElement;
        }
    }
}
