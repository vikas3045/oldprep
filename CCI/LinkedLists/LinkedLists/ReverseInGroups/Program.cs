using LinkedList;
using System;
using System.Collections.Generic;

namespace ReverseInGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            LinkedList.LinkedList list = new LinkedList.LinkedList();

            for (int i = 0; i < input.Length; i++)
            {
                list.AddLast(new ListNode() { Data = input[i] });
            }
            list.Print();
            LinkedList.LinkedList test = new LinkedList.LinkedList();
            LinkedList.LinkedList testB = new LinkedList.LinkedList();
            test.Head = ReverseInGroups(list.Head, 2);
            //testB.Head = ReverseInPairs(list.Head);
            //test.Head = ReverseInGroupsRecursive(list.Head, 3);
            test.Print();
            //testB.Print();
            Console.ReadLine();

        }

        public static ListNode ReverseInGroups(ListNode head, int k)
        {
            Stack<int> stack = new Stack<int>(k);
            LinkedList.LinkedList result = new LinkedList.LinkedList();
            ListNode resultHead = null;
            ListNode current = head;

            while (current != null)
            {
                while (stack.Count < k && current != null)
                {
                    stack.Push(current.Data);
                    current = current.Next;
                }

                while (stack.Count > 0)
                {
                    int data = stack.Pop();
                    result.AddLast(new ListNode(data));

                    resultHead = AddToLast(resultHead, new ListNode(data));
                }
            }

            return result.Head;
        }

        private static ListNode AddToLast(ListNode head, ListNode node)
        {
            if (head == null)
                return new ListNode(node.Data);

            var curr = head;
            while (curr.Next != null)
                curr = curr.Next;
            curr.Next = new ListNode(node.Data);

            return head;
        }

        public static ListNode ReverseInGroupsRecursive(ListNode head, int k)
        {
            ListNode current = head;
            ListNode next = null;
            ListNode prev = null;
            int count = 0;

            while (count < k && current != null)
            {
                next = current.Next;

                current.Next = prev;

                prev = current;
                current = next;
                count++;
            }

            if (next != null)
            {
                head.Next = ReverseInGroupsRecursive(next, k);
            }

            return prev;
        }

        public static ListNode ReverseInPairs(ListNode head)
        {
            if (head == null || head.Next == null)
                return head;
            ListNode secondNode = head.Next;
            ListNode nextToSecond = secondNode.Next;
            secondNode.Next = head;
            head.Next = ReverseInPairs(nextToSecond);
            head = secondNode;
            return head;
        }
    }
}
