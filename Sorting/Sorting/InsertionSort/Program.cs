using System;
using System.Linq;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = new int[] { 1, 8, 4, 2, 18, 5 };

            Console.WriteLine("Input Array:");
            PrintArray(inputArr);

            InsertionSort(inputArr);

            Console.WriteLine("\n\nAfter sorting:");
            PrintArray(inputArr);

            Console.ReadLine();
        }

        private static void InsertionSort(int[] inputArr)
        {
            int n = inputArr.Length;

            for (int i = 1; i <= n - 1; i++)
            {
                int value = inputArr[i];
                int insertionIndex = i;

                while (insertionIndex > 0 && inputArr[insertionIndex - 1] > value)
                {
                    inputArr[insertionIndex] = inputArr[insertionIndex - 1];
                    insertionIndex--;
                }

                inputArr[insertionIndex] = value;
            }
        }

        private static void PrintArray(int[] inputArr)
        {
            for (int i = 0; i < inputArr.Count(); i++)
                Console.Write(inputArr[i] + ((i == inputArr.Count() - 1) ? " " : ", "));
        }
    }
}
