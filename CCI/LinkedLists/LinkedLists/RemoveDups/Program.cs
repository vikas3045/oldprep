using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDups
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
            RemoveDupsWithoutBuffer(list.Head);
            //RemoveDups(list.Head);

            list.Print();
            Console.ReadLine();
        }

        public static void RemoveDups(ListNode head)
        {
            if (head == null) return;

            HashSet<int> hs = new HashSet<int>();
            ListNode prev = null;
            ListNode current = head;

            while (current != null)
            {
                ListNode next = current.Next;

                if (!hs.Contains(current.Data))
                {
                    hs.Add(current.Data);
                    prev = current;
                }
                else
                {
                    prev.Next = current.Next;
                }

                current = next;
            }
        }

        public static void RemoveDupsWithoutBuffer(ListNode head)
        {
            if (head == null) return;

            ListNode current = head;
            while (current != null)
            {
                ListNode runner = current;
                while (runner.Next != null)
                {
                    if (current.Data == runner.Next.Data)
                        runner.Next = runner.Next.Next;
                    else
                        runner = runner.Next;
                }

                current = current.Next;
            }
        }
    }
}
