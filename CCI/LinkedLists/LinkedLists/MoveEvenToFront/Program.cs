using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveEvenToFront
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 2, 1, 3, 4, 5, 6, 7 };

            LinkedList.LinkedList list = new LinkedList.LinkedList();

            for (int i = 0; i < input.Length; i++)
            {
                list.AddLast(new ListNode() { Data = input[i] });
            }

            list.Print();
            Console.WriteLine();
            list.Head = MoveEvenToFront(list.Head);

            list.Print();
            Console.WriteLine();

            Console.ReadLine();
        }

        private static ListNode MoveEvenToFront(ListNode head)
        {
            ListNode current = head;
            ListNode previous = null;

            while (current != null)
            {
                ListNode next = current.Next;

                if (current.Data % 2 == 0 && current != head)
                {
                    ListNode nodeToBeMoved = current;
                    previous.Next = next;
                    head = AddInFront(nodeToBeMoved, head);
                }
                else
                {
                    previous = current;
                }

                current = next;
            }

            return head;
        }

        private static ListNode AddInFront(ListNode nodeToBeMoved, ListNode head)
        {
            if (head == null)
                head = nodeToBeMoved;

            nodeToBeMoved.Next = head;
            head = nodeToBeMoved;
            return head;
        }
    }
}
