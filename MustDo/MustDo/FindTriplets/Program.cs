using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTriplets
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 0, -1, 2, -3, 1 };
            int[] arr = { 0, -1, 1 };
            List<List<int>> lstTriplets = new List<List<int>>();
            List<int> curSol = new List<int>();

            FindTriplets(arr, 0, curSol, lstTriplets);

            foreach (var triplet in lstTriplets)
            {
                foreach (var item in triplet)
                    Console.Write(item + " ");

                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void FindTriplets(int[] arr, int curPos, List<int> curSol, List<List<int>> lstTriplets)
        {
            if (curPos >= arr.Length)
            {
                if (curSol.Count == 3 && curSol.Sum() == 0)
                    lstTriplets.Add(curSol);

                return;
            }

            for (int i = curPos; i < arr.Length; i++)
            {
                List<int> subSol = new List<int>(curSol);
                subSol.Add(arr[curPos]);

                FindTriplets(arr, curPos + 1, subSol, lstTriplets);
                FindTriplets(arr, curPos + 1, curSol, lstTriplets);
                FindTriplets(arr, curPos + 1, new List<int>() { arr[curPos] }, lstTriplets);
            }
        }
    }
}
