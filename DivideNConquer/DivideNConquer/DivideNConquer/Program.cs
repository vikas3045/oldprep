using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideNConquer
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] inputArr = { 0, 1, 0, 3, 4, 50 };

            Console.WriteLine(IndexSearch(inputArr, 2, 5));
            Console.ReadLine();
        }

        public static int IndexSearch(int[] inputArr, int l, int r)
        {
            if (r > l)
            {
                int mid = (r - l) / 2;

                if (inputArr[mid] == mid)
                    return mid;
                else if (inputArr[mid] < mid)
                    return IndexSearch(inputArr, l, mid);
                else if (inputArr[mid] > mid)
                    return IndexSearch(inputArr, mid + 1, r);
            }
            return -1;
        }
    }
}
