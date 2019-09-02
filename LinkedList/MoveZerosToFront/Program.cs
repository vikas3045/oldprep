using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveZerosToFront
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 0, 1, 3, 0, 4, 0, 9 };

            LinkedList.LinkedList list = new LinkedList.LinkedList();

            for (int i = 0; i < input.Length; i++)
            {
                list.InsertAtEnd(new LinkedList.ListNode() { Data = input[i] });
            }

            list.Print();

            list.Head = MoveZerosToFront2(list.Head);

            list.Print();

            Console.ReadLine();
        }

        public static LinkedList.ListNode MoveZerosToFront(LinkedList.ListNode head)
        {
            var currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.Next != null)
                {
                    if (currentNode.Next.Data == 0)
                    {
                        var nodeToBeMoved = currentNode.Next;
                        currentNode.Next = nodeToBeMoved.Next;
                        nodeToBeMoved.Next = head;
                        head = nodeToBeMoved;
                    }
                }

                currentNode = currentNode.Next;
            }

            return head;
        }

        public static ListNode MoveZerosToFront2(ListNode head)
        {
            ListNode current = head;
            ListNode prev = null;

            while (current != null)
            {
                ListNode next = current.Next;
                if (current.Data == 0)
                {
                    if (prev != null)
                    {
                        ListNode nodeToBeMoved = current;
                        prev.Next = current.Next;
                        nodeToBeMoved.Next = head;
                        head = nodeToBeMoved;
                    }
                }

                prev = current;
                current = next;
            }

            return head;
        }
    }
}
