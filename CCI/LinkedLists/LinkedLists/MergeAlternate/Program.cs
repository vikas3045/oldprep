using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeAlternate
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputA = new int[] { 1, 3, 5, 7, 9 };

            LinkedList.LinkedList listA = new LinkedList.LinkedList();

            for (int i = 0; i < inputA.Length; i++)
            {
                listA.AddLast(new ListNode() { Data = inputA[i] });
            }


            int[] inputB = new int[] { 2, 4, 6, 8, 10, 11, 12, 13 };

            LinkedList.LinkedList listB = new LinkedList.LinkedList();

            for (int i = 0; i < inputB.Length; i++)
            {
                listB.AddLast(new ListNode() { Data = inputB[i] });
            }

            LinkedList.LinkedList result = new LinkedList.LinkedList();
            result.Head = MergeAlternate(listA.Head, listB.Head);
            result.Print();

            LinkedList.LinkedList resultA = new LinkedList.LinkedList();
            resultA.Head = MergeAlternateIterative(listA.Head, listB.Head);
            resultA.Print();
            Console.ReadLine();
        }

        public static ListNode MergeAlternate(ListNode headA, ListNode headB)
        {
            if (headA == null && headB == null) return null;
            if (headA == null) return headB;
            if (headB == null) return headA;

            ListNode first = new ListNode();
            ListNode second = new ListNode();
            first.Data = headA.Data;
            second.Data = headB.Data;
            first.Next = second;

            second.Next = MergeAlternate(headA.Next, headB.Next);

            return first;
        }

        public static ListNode MergeAlternateIterative(ListNode headA, ListNode headB)
        {
            if (headA == null && headB == null) return null;
            if (headA == null) return headB;
            if (headB == null) return headA;

            LinkedList.LinkedList result = new LinkedList.LinkedList();
            while (headA != null && headB != null)
            {
                ListNode tempA = new ListNode();
                ListNode tempB = new ListNode();

                tempA.Data = headA.Data;
                tempB.Data = headB.Data;
                tempA.Next = tempB;
                result.AddLast(tempA);

                headA = headA.Next;
                headB = headB.Next;
            }

            if (headA != null)
            {
                result.AddLast(headA);
            }

            if (headB != null)
            {
                result.AddLast(headB);
            }

            return result.Head;
        }
    }
}
