using System;
using LinkedList;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateList
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

            LinkedList.LinkedList result = new LinkedList.LinkedList();
            result.Head = RotateList(list.Head, 4);
            result.Print();

            Console.ReadLine();
        }

        private static ListNode RotateList(ListNode head, int k)
        {
            if (head == null) return null;

            ListNode current = head;

            for (int i = 1; i < k; i++)
            {
                current = current.Next;
                if (current == null)
                    throw new Exception("Invalid value of k");
            }

            ListNode nodesToBeRotated = current.Next;
            current.Next = null;
            ListNode reversedNodes = ReverseList(nodesToBeRotated);
            current = reversedNodes;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = head;
            return reversedNodes;
        }

        private static ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode current = head;
            while (current != null)
            {
                ListNode next = current.Next;

                current.Next = prev;
                prev = current;

                current = next;
            }
            return prev;
        }
    }
}
