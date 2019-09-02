using LinkedList;
using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputA = new int[] { 10, 3, 2, 11, 34, 1, 76 };

            LinkedList.LinkedList listA = new LinkedList.LinkedList();

            for (int i = 0; i < inputA.Length; i++)
            {
                listA.AddLast(new ListNode() { Data = inputA[i] });
            }

            listA.Print();

            LinkedList.LinkedList list = new LinkedList.LinkedList();
            list.Head = MergeSort(listA.Head);

            list.Print();
            Console.ReadLine();
        }

        public static ListNode MergeSort(ListNode head)
        {
            if (head == null || head.Next == null)
                return head;

            ListNode middleNode = GetMiddleNode(head);
            ListNode nextToMiddle = middleNode.Next;

            middleNode.Next = null;
            ListNode left = MergeSort(head);
            ListNode right = MergeSort(nextToMiddle);
            return MergeLists(left, right);
        }

        private static ListNode GetMiddleNode(ListNode head)
        {
            ListNode slowPtr = head;
            ListNode fastPtr = head;

            if (head.Next.Next == null) return head;

            while (fastPtr != null && fastPtr.Next != null)
            {
                slowPtr = slowPtr.Next;
                fastPtr = fastPtr.Next.Next;
            }

            return slowPtr;
        }


        //Below method works correctly
        //public static ListNode MergeSort(ListNode head)
        //{
        //    if (head == null) return null;
        //    if (head.Next == null) return head;

        //    int length = GetLength(head);
        //    int mid = length / 2;

        //    LinkedList.LinkedList listA = new LinkedList.LinkedList();
        //    LinkedList.LinkedList listB = new LinkedList.LinkedList();

        //    for (int i = 0; i <= length - 1; i++)
        //    {
        //        ListNode temp = new ListNode();
        //        temp.Data = head.Data;

        //        if (i < mid)
        //        {
        //            listA.AddLast(temp);
        //        }
        //        else
        //        {
        //            listB.AddLast(temp);
        //        }

        //        head = head.Next;
        //    }

        //    var sortedHeadA = MergeSort(listA.Head);
        //    var sortedHeadB = MergeSort(listB.Head);
        //    return MergeLists(sortedHeadA, sortedHeadB);
        //}

        private static ListNode MergeLists(ListNode head1, ListNode head2)
        {
            if (head1 == null) return head2;
            if (head2 == null) return head1;

            LinkedList.LinkedList result = new LinkedList.LinkedList();

            while (head1 != null && head2 != null)
            {
                ListNode temp = new ListNode();
                if (head1.Data <= head2.Data)
                {
                    temp.Data = head1.Data;
                    head1 = head1.Next;
                }
                else
                {
                    temp.Data = head2.Data;
                    head2 = head2.Next;
                }

                result.AddLast(temp);
            }

            if (head1 != null)
                result.AddLast(head1);

            if (head2 != null)
                result.AddLast(head2);

            return result.Head;
        }

        private static int GetLength(ListNode head)
        {
            int length = 0;

            if (head != null)
            {
                while (head != null)
                {
                    length++;
                    head = head.Next;
                }
            }

            return length;
        }
    }
}
