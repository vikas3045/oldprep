using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveIfGreaterAtRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 12, 15, 10, 11, 5, 6, 2, 3 };
            //int[] input = new int[] { 10, 20, 30, 40, 50 };

            LinkedList.LinkedList list = new LinkedList.LinkedList();

            for (int i = 0; i < input.Length; i++)
            {
                list.AddLast(new ListNode() { Data = input[i] });
            }

            LinkedList.LinkedList listA = new LinkedList.LinkedList();
            listA.Head = RemoveIfGreaterAtRight(list.Head);
            listA.Print();

            Console.ReadLine();
        }

        public static ListNode RemoveIfGreaterAtRight(ListNode head)
        {
            if (head == null || head.Next == null)
                return head;

            ListNode tail = RemoveIfGreaterAtRight(head.Next);

            if (tail != null && head.Data >= tail.Data)
            {
                head.Next = tail;
                return head;
            }
            else if (tail != null)
            {
                return tail;
            }

            return null;
        }
    }
}
