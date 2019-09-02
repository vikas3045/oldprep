using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumLists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputA = new int[] { 7, 1 };

            LinkedList.LinkedList listA = new LinkedList.LinkedList();

            for (int i = 0; i < inputA.Length; i++)
            {
                listA.AddLast(new ListNode() { Data = inputA[i] });
            }

            int[] inputB = new int[] { 5, 9, 2 };

            LinkedList.LinkedList listB = new LinkedList.LinkedList();

            for (int i = 0; i < inputB.Length; i++)
            {
                listB.AddLast(new ListNode() { Data = inputB[i] });
            }

            LinkedList.LinkedList sum = new LinkedList.LinkedList();
            sum.Head = SumLists(listA.Head, listB.Head);

            LinkedList.LinkedList sumForwardRepresentation = new LinkedList.LinkedList();
            sumForwardRepresentation.Head = SumListsForwardRepresentation(listA.Head, listB.Head);

            sum.Print();
            sumForwardRepresentation.Print();

            Console.ReadLine();
        }

        public static ListNode SumListsAlt(ListNode headA, ListNode headB, int carry = 0)
        {
            if (headA == null && headB == null && carry == 0)
                return null;
            else if (headA == null && headB == null)
                return new ListNode(carry);
            else if (headA == null)
                return new ListNode(headB.Data + carry);
            else if (headB == null)
                return new ListNode(headA.Data + carry);

            ListNode resultHead = new ListNode();

            int val = headA.Data + headB.Data + carry;
            resultHead.Data = val % 10;
            carry = val > 9 ? 1 : 0;

            resultHead.Next = SumListsAlt(headA.Next, headB.Next, carry);

            return resultHead;
        }

        public static ListNode SumLists(ListNode listA, ListNode listB, int carry = 0)
        {
            if (listA == null && listB == null && carry == 0)
                return null;

            ListNode result = new ListNode();
            int value = carry;

            if (listA != null)
                value += listA.Data;

            if (listB != null)
                value += listB.Data;

            result.Data = value % 10;

            if (listA != null || listB != null)
            {
                result.Next = SumLists(listA == null ? null : listA.Next, listB == null ? null : listB.Next, value >= 10 ? 1 : 0);
            }

            return result;
        }

        public static ListNode SumListsForwardRepresentation(ListNode headA, ListNode headB)
        {
            int headALength = GetLength(headA);
            int headBLength = GetLength(headB);

            Carry carry = new Carry();
            ListNode result = new ListNode();

            if (headALength == headBLength)
            {
                result = SumListsForwardRepresentation(headA, headB, carry);
            }
            else
            {
                if (headALength > headBLength)
                    headB = AppendZerosInFront(headB, Math.Abs(headALength - headBLength));
                else
                    headA = AppendZerosInFront(headA, Math.Abs(headALength - headBLength));

                result = SumListsForwardRepresentation(headA, headB, carry);
            }

            if (carry.val > 0)
            {
                ListNode carryNode = new ListNode(carry.val);
                carryNode.Next = result;
                return carryNode;
            }

            return result;
        }

        private static ListNode SumListsForwardRepresentation(ListNode headA, ListNode headB, Carry carry)
        {
            if (headA == null || headB == null)
                return null;

            ListNode next = SumListsForwardRepresentation(headA.Next, headB.Next, carry);

            int value = carry.val + headA.Data + headB.Data;

            ListNode result = new ListNode();
            result.Data = value % 10;
            carry.val = value >= 10 ? 1 : 0;

            result.Next = next;

            return result;
        }

        private static ListNode AppendZerosInFront(ListNode head, int difference)
        {
            if (head == null) return null;

            int count = 0;
            while (count < difference)
            {
                ListNode zeroNode = new ListNode(0);
                zeroNode.Next = head;
                head = zeroNode;

                count++;
            }

            return head;
        }

        private static int GetLength(ListNode head)
        {
            int length = 0;
            ListNode current = head;

            while (current != null)
            {
                length++;
                current = current.Next;
            }

            return length;
        }
    }
}
