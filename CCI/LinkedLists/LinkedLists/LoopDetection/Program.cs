using LinkedList;
using System;

namespace LoopDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputA = new int[] { 7, 1, 6, 2 };

            ListNode cycleNode = new ListNode();
            ListNode node = new ListNode();
            ListNode cycleNode2 = new ListNode();

            cycleNode.Data = 10;
            cycleNode.Next = cycleNode2;
            cycleNode2.Data = 11;
            cycleNode.Next = node;
            node.Data = 3;
            node.Next = cycleNode;

            LinkedList.LinkedList listA = new LinkedList.LinkedList();

            for (int i = 0; i < inputA.Length; i++)
            {
                listA.AddLast(new ListNode() { Data = inputA[i] });
            }

            //listA.AddLast(node);

            Console.WriteLine(GetLoopNode(listA.Head).Data);
            Console.ReadLine();
        }

        public static ListNode GetLoopNode(ListNode head)
        {
            ListNode slowPtr = head;
            ListNode fastPtr = head;

            bool IsLoopPresent = false;

            while (fastPtr != null && fastPtr.Next != null)
            {
                slowPtr = slowPtr.Next;
                fastPtr = fastPtr.Next.Next;

                if (slowPtr == fastPtr)
                {
                    IsLoopPresent = true;
                    break;
                }
            }

            if (IsLoopPresent)
            {
                fastPtr = head;

                while (slowPtr != fastPtr)
                {
                    slowPtr = slowPtr.Next;
                    fastPtr = fastPtr.Next;
                }
            }

            return fastPtr;
        }
    }
}
