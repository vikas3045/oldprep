using LinkedList;
using System;

namespace Partition
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 3, 5, 8, 5, 10, 2, 1 };

            LinkedList.LinkedList list = new LinkedList.LinkedList();

            for (int i = 0; i < input.Length; i++)
            {
                list.AddLast(new ListNode() { Data = input[i] });
            }

            list.Print();
            Console.WriteLine();
            //Partition(list.Head, 5);

            PartitionAlt(list.Head, 5);

            list.Print();
            Console.ReadLine();
        }

        private static void PartitionAlt(ListNode head, int x)
        {
            if (head == null) return;

            ListNode current = head;
            while (current != null)
            {
                ListNode next = current.Next;

                if (current.Data < x)
                    AddToFirst(current, head);

                current = next;
            }
        }

        private static void AddToFirst(ListNode current, ListNode head)
        {
            if (head == null)
                head = current;

            current.Next = head;
            head = current;
        }

        private static void Partition(ListNode head, int x)
        {
            ListNode partitionIndex = head;
            ListNode current = head;

            while (current != null)
            {
                if (current.Data < x)
                {
                    ListNode temp = current;
                    current.Data = partitionIndex.Data;
                    partitionIndex.Data = temp.Data;

                    partitionIndex = partitionIndex.Next;
                }

                current = current.Next;
            }
        }
    }
}
