using System;
using System.Linq;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = new int[] { 2, 8, 6, 3, 7, 5, 1, 4 };

            Console.WriteLine("Input Array:");
            PrintArray(inputArr);

            QuickSort(inputArr, 0, inputArr.Length - 1);

            Console.WriteLine("\n\nAfter sorting:");
            PrintArray(inputArr);

            Console.ReadLine();
        }

        private static void QuickSort(int[] inputArr, int start, int end)
        {
            if (start < end)
            {
                int partitionIndex = Partition(inputArr, start, end);
                QuickSort(inputArr, start, partitionIndex - 1);
                QuickSort(inputArr, partitionIndex + 1, end);
            }
        }

        private static int Partition(int[] inputArr, int start, int end)
        {
            int pivot = inputArr[end];
            int partitionIndex = start;

            for (int i = start; i <= end - 1; i++)
            {
                if (inputArr[i] < pivot)
                {
                    Swap(ref inputArr[i], ref inputArr[partitionIndex]);
                    partitionIndex++;
                }
            }

            Swap(ref inputArr[partitionIndex], ref inputArr[end]);

            return partitionIndex;
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
