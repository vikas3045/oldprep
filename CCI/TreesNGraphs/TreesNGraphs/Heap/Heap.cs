using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class Heap
    {
        public int[] arr;
        public int count;
        public int capacity;
        public Type heapType;

        public enum Type
        {
            Min = 0,
            Max = 1
        }

        public Heap(int capacity, Type heapType)
        {
            this.count = 0;
            this.heapType = heapType;
            this.capacity = capacity;
            this.arr = new int[capacity];
        }

        public int GetParentIndex(int index)
        {
            if (index <= 0 || index >= this.count)
                return -1;

            return (index - 1) / 2;
        }

        public int GetLeftChildIndex(int index)
        {
            int leftIndex = (2 * index) + 1;

            if (leftIndex > 0 && leftIndex <= this.count - 1)
                return leftIndex;
            else
                return -1;
        }

        public int GetRightChildIndex(int index)
        {
            int rightIndex = (2 * index) + 2;

            if (rightIndex > 0 && rightIndex <= this.count - 1)
                return rightIndex;
            else
                return -1;
        }

        public void Insert(int data)
        {
            // 1. Increase the count
            count++;

            // 2. Find the appropriate location of insertion
            // starting from bottom and moving up as per heap property
            int i = count - 1;
            while (i > 0 && data > arr[(i - 1) / 2])
            {
                arr[i] = arr[(i - 1) / 2];
                i = (i - 1) / 2;
            }

            // 3. Insert the element
            arr[i] = data;
        }

        public int Delete()
        {
            if (count == 0)
                return -1;
            // 1. Copy first element in some variable
            int temp = arr[0];

            // 2. Copy last element in first element
            arr[0] = arr[count - 1];

            // 3. Decrement count
            count--;

            // 4. Percolate down
            PercolateDown(0);

            return temp;
        }

        public int GetMaximum()
        {
            if (this.count == 0)
                return -1;

            return arr[0];
        }

        public void PercolateDown(int index)
        {
            int leftChildIndex = GetLeftChildIndex(index);
            int rightChildIndex = GetRightChildIndex(index);
            int max;

            if (leftChildIndex != -1 && arr[leftChildIndex] > arr[index])
                max = leftChildIndex;
            else
                max = index;

            if (rightChildIndex != -1 && arr[rightChildIndex] > arr[max])
                max = rightChildIndex;

            if (max != index)
            {
                int temp = arr[max];
                arr[max] = arr[index];
                arr[index] = temp;

                PercolateDown(max);
            }
        }
    }
}
