using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folding
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

            Fold(list.Head);

            Console.ReadLine();
        }

        public static void Fold(ListNode head)
        {
            ListNode sPtr, fPtr;
            sPtr = head; fPtr = head;
            while (fPtr != null && fPtr.Next != null)
            {
                sPtr = sPtr.Next;
                fPtr = fPtr.Next.Next;
            }

            ListNode reverseLastHalf = ReverseList(sPtr.Next);
            sPtr.Next = null;

            ListNode current = head;

            while (current != null && reverseLastHalf != null)
            {
                ListNode nextA = current.Next;
                ListNode nextB = reverseLastHalf.Next;

                current.Next = reverseLastHalf;
                //Both below lines are correct as they are references to same variable
                //reverseLastHalf.Next = nextA;
                current.Next.Next = nextA;

                current = nextA;
                reverseLastHalf = nextB;
            }

            if (current != null)
                current = current.Next;
            if (reverseLastHalf != null)
                current = reverseLastHalf;
        }

        private static ListNode ReverseList(ListNode head)
        {
            if (head == null || head.Next == null) return head;

            ListNode p = ReverseList(head.Next);
            head.Next.Next = head;
            head.Next = null;
            return p;
        }
    }
}
