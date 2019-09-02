using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteMiddleNode
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
            DeleteMiddleNode(list.Head.Next.Next);

            list.Print();
            Console.ReadLine();
        }

        private static void DeleteMiddleNode(ListNode node)
        {
            if (node == null) return;

            if (node.Next != null)
            {
                node.Data = node.Next.Data;
                node.Next = node.Next.Next;
            }
        }
    }
}
