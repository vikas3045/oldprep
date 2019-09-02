using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace ReverseList
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
            test.Head = ReverseList(list.Head);
            ///test.Head = ReverseListIterative(list.Head);

            test.Print();

            Console.ReadLine();
        }

        private static ListNode ReverseList(ListNode head)
        {
            if (head == null) return null;

            ListNode secondNode = head.Next;

            if (secondNode == null) return head;
                        
            ListNode reverseRest = ReverseList(secondNode);
            secondNode.Next = head;
            head.Next = null;

            return reverseRest;
        }

        public static ListNode ReverseListIterative(ListNode head)
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
