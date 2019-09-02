using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KthNodeFromEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 1, 5, 2, 3, 4, 2, 5, 9 };

            LinkedList.LinkedList list = new LinkedList.LinkedList();

            for (int i = 0; i < input.Length; i++)
            {
                list.AddLast(new ListNode() { Data = input[i] });
            }

            list.Print();
            Console.WriteLine();
            Console.WriteLine(KthNodeFromEnd(list.Head, 5));
            Console.WriteLine(KthNodeFromEndAlt(list.Head, 5));
            Console.ReadLine();
        }

        private static int KthNodeFromEndAlt(ListNode head, int k)
        {
            if (head == null) return -1;

            ListNode current = head;
            ListNode runner = head;

            for (int i = 0; i < k; i++)
            {
                if (runner.Next != null)
                    runner = runner.Next;
                else
                    return -1;
            }

            while (runner != null)
            {
                current = current.Next;
                runner = runner.Next;
            }

            return current.Data;
        }

        private static int KthNodeFromEnd(ListNode head, int k)
        {
            ListNode p1 = head;
            ListNode p2 = head;

            int count = 0;
            while (p1 != null && count < k)
            {
                p1 = p1.Next;
                count++;
            }

            while (p1 != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }
            return p2.Data;
        }
    }
}
