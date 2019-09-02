using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputA = new int[] { 7, 1, 6, 2 };

            ListNode node = new ListNode();
            node.Data = 3;
            node.Next = new ListNode() { Data = 10 };

            LinkedList.LinkedList listA = new LinkedList.LinkedList();

            for (int i = 0; i < inputA.Length; i++)
            {
                listA.AddLast(new ListNode() { Data = inputA[i] });
            }

            int[] inputB = new int[] { 5, 9, 6, 2 };

            LinkedList.LinkedList listB = new LinkedList.LinkedList();

            for (int i = 0; i < inputB.Length; i++)
            {
                listB.AddLast(new ListNode() { Data = inputB[i] });
            }
            listA.AddLast(node);
            listB.AddLast(node);

            Console.WriteLine(GetIntersection(listA.Head, listB.Head).Data);

            Console.ReadLine();
        }

        public static ListNode GetIntersection(ListNode a, ListNode b)
        {
            int aLength = GetLength(a);
            int bLength = GetLength(b);
            int diff = Math.Abs(aLength - bLength);

            ListNode shorter, longer;

            if (aLength > bLength)
            {
                longer = a;
                shorter = b;
            }
            else
            {
                longer = b;
                shorter = a;
            }

            // Giving the longer list a head start
            for (int i = 0; i < diff; i++)
            {
                longer = longer.Next;
            }

            while (longer != null && shorter != null)
            {
                if (longer == shorter)
                    return longer;

                longer = longer.Next;
                shorter = shorter.Next;
            }

            return null;
        }

        private static int GetLength(ListNode b)
        {
            if (b == null)
                return 0;

            int length = 1;
            while (b.Next != null)
            {
                length++;
                b = b.Next;
            }

            return length;
        }
    }
}
