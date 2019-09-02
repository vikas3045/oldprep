using System;
using System.Linq;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] inputArr = new int[] { 1, 8, 4, 2, 18, 5 };
            int[] inputArr = new int[] { 1, 8, 2, 5, 18 };

            Console.WriteLine("Input Array:");
            PrintArray(inputArr);

            BubbleSortImproved(inputArr);

            Console.WriteLine("\n\nAfter sorting:");
            PrintArray(inputArr);

            Console.ReadLine();
        }

        public static void BubbleSort(int[] inputArr)
        {
            int n = inputArr.Count();

            for (int pass = n - 1; pass >= 0; pass--)
            {
                for (int i = 0; i <= pass - 1; i++)
                {
                    if (inputArr[i] > inputArr[i + 1])
                    {
                        Swap(ref inputArr[i], ref inputArr[i + 1]);
                    }
                }
            }
        }

        public static void BubbleSortImproved(int[] arr)
        {
            bool swapped = true;
            for (int pass = arr.Length - 1; pass >= 0 && swapped; pass--)
            {
                swapped = false;
                for (int i = 0; i <= pass - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                        swapped = true;
                    }
                }
            }
        }

        private static void Swap<T>(ref T element1, ref T element2)
        {
            T temp = element1;
            element1 = element2;
            element2 = temp;
        }

        private static void PrintArray(int[] inputArr)
        {
            for (int i = 0; i < inputArr.Count(); i++)
                Console.Write(inputArr[i] + ((i == inputArr.Count() - 1) ? " " : ", "));
        }
    }
}
