using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectAndRemove
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputA = new int[] { 7, 1, 6, 2 };

            ListNode cycleNode = new ListNode();
            ListNode node = new ListNode();
            ListNode cycleNode2 = new ListNode();

            cycleNode.Data = 10;
            cycleNode.Next = cycleNode2;
            cycleNode2.Data = 11;
            cycleNode.Next = node;
            node.Data = 3;
            node.Next = cycleNode;

            LinkedList.LinkedList listA = new LinkedList.LinkedList();

            for (int i = 0; i < inputA.Length; i++)
            {
                listA.AddLast(new ListNode() { Data = inputA[i] });
            }

            listA.AddLast(node);

            Console.WriteLine(DetectAndRemove(listA.Head));
            Console.ReadLine();
        }

        private static bool DetectAndRemove(ListNode head)
        {
            ListNode slowPtr = head;
            ListNode fastPtr = head;

            bool isLoopPresent = false;

            while (fastPtr != null && fastPtr.Next != null)
            {
                slowPtr = slowPtr.Next;
                fastPtr = fastPtr.Next.Next;

                if (slowPtr == fastPtr)
                {
                    isLoopPresent = true;
                    break;
                }
            }

            if (!isLoopPresent)
                return false;

            fastPtr = head;
            while (fastPtr.Next != slowPtr.Next)
            {
                fastPtr = fastPtr.Next;
                slowPtr = slowPtr.Next;
            }
            slowPtr.Next = null;

            /////Below approach also works
            //// Get loop length
            //fastPtr = fastPtr.Next;
            //int loopLength = 1;

            //while (fastPtr != slowPtr)
            //{
            //    fastPtr = fastPtr.Next;
            //    loopLength++;
            //}


            //fastPtr = head;
            //while (fastPtr != slowPtr)
            //{
            //    fastPtr = fastPtr.Next;
            //    slowPtr = slowPtr.Next;
            //}
            //for (int i = 1; i < loopLength; i++)
            //{
            //    fastPtr = fastPtr.Next;
            //}
            //fastPtr.Next = null;

            return isLoopPresent;
        }
    }
}
