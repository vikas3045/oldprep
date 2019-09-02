using Heaps;
using System;

namespace BuildHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArr = new int[] { 2, 8, 5, 10, 9, 3, 1 };
            Heap heap = new Heap(10, Heap.Type.Max);

            BuildHeap(heap, inputArr);
            for (int i = 0; i < heap.count; i++)
                Console.Write(heap.arr[i] + " ");

            Console.WriteLine();
            Console.WriteLine("Deleting");
            heap.Delete();

            for (int i = 0; i < heap.count; i++)
                Console.Write(heap.arr[i] + " ");

            Console.WriteLine();
            Console.WriteLine("Inserting");
            heap.Insert(50);

            for (int i = 0; i < heap.count; i++)
                Console.Write(heap.arr[i] + " ");

            Console.ReadLine();
        }

        public static void BuildHeap(Heap heap, int[] inputArr)
        {    
            if (heap == null)
                return;

            int n = inputArr.Length;
            for (int i = 0; i < n; i++)
            {
                heap.arr[i] = inputArr[i];
            }

            heap.count = n;

            for (int i = ((n - 1) - 1) / 2; i >= 0; i--)
            {
                heap.PercolateDown(i);
            }
        }
    }
}
