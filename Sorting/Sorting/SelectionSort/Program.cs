using System;
using System.Linq;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = new int[] { 18, 8, 4, 2, 9, 1 };

            Console.WriteLine("Input Array:");
            PrintArray(inputArr);

            SelectionSort(inputArr);

            Console.WriteLine("\n\nAfter sorting:");
            PrintArray(inputArr);

            Console.ReadLine();
        }

        public static void SelectionSort(int[] inputArr)
        {
            var n = inputArr.Length;
            for (int i = 0; i <= n - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j <= n - 1; j++)
                {
                    if (inputArr[j] < inputArr[min])
                        min = j;
                }

                Swap(ref inputArr[min], ref inputArr[i]);
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
