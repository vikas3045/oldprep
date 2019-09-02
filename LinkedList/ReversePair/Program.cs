using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace ReversePair
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };

            LinkedList.LinkedList list = new LinkedList.LinkedList();

            for (int i = 0; i < input.Length; i++)
            {
                list.InsertAtEnd(new LinkedList.ListNode() { Data = input[i] });
            }

            list.Print();

            //list.Head = ReversePairRecursive(list.Head);
            list.Head = ReversePairIterative(list.Head);

            list.Print();

            Console.ReadLine();
        }

        private static ListNode ReversePairRecursive(ListNode head)
        {
            if (head == null || head.Next == null)
                return head;

            var temp = head.Next;
            head.Next = temp.Next;
            temp.Next = head;
            head = temp;

            head.Next.Next = ReversePairRecursive(head.Next.Next);


            return head;
        }

        private static ListNode ReversePairIterative(ListNode head)
        {
            ListNode temp = null;
            ListNode reversedHead = null;
            while (head != null && head.Next != null)
            {
                if (temp != null)
                {
                    temp.Next.Next = head.Next;
                }

                temp = head.Next;
                head.Next = head.Next.Next;
                temp.Next = head;

                if (reversedHead == null)
                {
                    reversedHead = temp;
                }

                head = head.Next;
            }

            return reversedHead;
        }
    }
}
