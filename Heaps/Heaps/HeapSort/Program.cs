using System;
using System.Linq;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = new int[] { 1, 8, 4, 2, 18, 5 };

            Console.WriteLine("Input Array:");
            PrintArray(inputArr);

            HeapSort(inputArr);

            Console.WriteLine("\n\nAfter sorting:");
            PrintArray(inputArr);

            Console.ReadLine();
        }

        public static void HeapSort(int[] inputArr)
        {
            int count = inputArr.Length;

            //Build Heap (rearrange array)
            for (int i = ((count - 1) - 1) / 2; i >= 0; i--)
            {
                Heapify(inputArr, count, i);
            }

            for (int i = count - 1; i >= 0; i--)
            {
                int temp = inputArr[0];
                inputArr[0] = inputArr[i];
                inputArr[i] = temp;

                Heapify(inputArr, i, 0);
            }
        }

        private static void Heapify(int[] inputArr, int count, int index)
        {
            int max = index;
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            if (leftChildIndex < count && inputArr[leftChildIndex] > inputArr[max])
                max = leftChildIndex;

            if (rightChildIndex < count && inputArr[rightChildIndex] > inputArr[max])
                max = rightChildIndex;

            if (max != index)
            {
                int temp = inputArr[index];
                inputArr[index] = inputArr[max];
                inputArr[max] = temp;

                Heapify(inputArr, count, max);
            }
        }

        private static void PrintArray(int[] inputArr)
        {
            for (int i = 0; i < inputArr.Count(); i++)
                Console.Write(inputArr[i] + ((i == inputArr.Count() - 1) ? " " : ", "));
        }
    }
}
