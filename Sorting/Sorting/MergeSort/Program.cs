using System;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = new int[] { 10, 8, 4, 2, 18, 5, 1 };

            Console.WriteLine("Input Array:");
            PrintArray(inputArr);

            MergeSort(inputArr, 0, inputArr.Count() - 1);

            Console.WriteLine("\n\nAfter sorting:");
            PrintArray(inputArr);

            Console.ReadLine();
        }

        static public void MergeSort(int[] numbers, int left, int right)
        {
            if (left < right)
            {
                int mid = (right + left) / 2;
                MergeSort(numbers, left, mid);
                MergeSort(numbers, (mid + 1), right);
                Merge(numbers, left, (mid + 1), right);
            }
        }

        private static void Merge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[numbers.Length];
            int tmp_pos = left;
            int left_end = (mid - 1);            

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            int num_elements = (right - left + 1);

            for (int i = 0; i <= num_elements - 1; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        private static void PrintArray(int[] inputArr)
        {
            for (int i = 0; i < inputArr.Length; i++)
                Console.Write(inputArr[i] + ((i == inputArr.Length - 1) ? " " : ", "));
        }
    }
}
