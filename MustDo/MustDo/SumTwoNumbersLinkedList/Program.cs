using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumTwoNumbersLinkedList
{
    class Program
    {
        static int carryForward = 0;

        static void Main(string[] args)
        {
            int[] inputA = new int[] { 5, 6 };

            LinkedList.LinkedList listA = new LinkedList.LinkedList();

            for (int i = 0; i < inputA.Length; i++)
            {
                listA.AddLast(new ListNode() { Data = inputA[i] });
            }

            int[] inputB = new int[] { 8, 4, 2 };

            LinkedList.LinkedList listB = new LinkedList.LinkedList();

            for (int i = 0; i < inputB.Length; i++)
            {
                listB.AddLast(new ListNode() { Data = inputB[i] });
            }

            LinkedList.LinkedList listSum = new LinkedList.LinkedList();
            listSum.Head = SumTwoNumbersLinkedList(listA.Head, listB.Head, carryForward);

            listSum.Print();

            Console.ReadLine();
        }

        private static ListNode SumTwoNumbersLinkedList(ListNode headA, ListNode headB, int carry)
        {
            if (headA == null && headB == null && carry == 0)
                return null;
            else if (headA == null && headB == null && carry > 0)
                return new ListNode(carry);

            ListNode sum = new ListNode();
            sum.Next = SumTwoNumbersLinkedList((headA != null) ? headA.Next : null, (headB != null) ? headB.Next : null, 0);

            int headAData = headA != null ? headA.Data : 0;
            int headBData = headB != null ? headB.Data : 0;
            int data = headAData + headBData + carryForward;

            sum.Data = data % 10;
            carryForward = data > 9 ? 1 : 0;


            return sum;
        }
    }
}
