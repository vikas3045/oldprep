using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatten
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiNode head = new MultiNode(5);

            MultiNode list1 = new MultiNode(1);

            MultiNode sub = new MultiNode();
            sub.Right = new MultiNode(10);
            MultiNode list1Sub = new MultiNode(12);
            list1Sub.Right = sub;
            list1Sub.Down = new MultiNode(3);

            list1.Down = list1Sub;
            list1.Right = new MultiNode(4);



            head.Right = list1;

            LinkedListNode<int> test = Flatten(head);
            var flattened = FlattenAlt(head);

            Console.ReadLine();

        }

        public static MultiNode FlattenAlt(MultiNode head)
        {
            if (head == null) return null;

            Queue<MultiNode> q = new Queue<MultiNode>();
            MultiNode resultHead = null;
            MultiNode currResult = null;

            q.Enqueue(head);
            while (q.Count > 0)
            {
                MultiNode current = q.Dequeue();

                if (current.Right != null)
                    q.Enqueue(current.Right);
                if (current.Down != null)
                    q.Enqueue(current.Down);

                current.Right = null;
                current.Down = null;

                if (resultHead == null)
                {
                    resultHead = current;
                    currResult = resultHead;
                }
                currResult.Right = current;
                currResult = currResult.Right;
                //else
                //    AddToLast(current, resultHead);
            }

            return resultHead;
        }

        private static void AddToLast(MultiNode node, MultiNode head)
        {
            if (head == null)
                head = node;

            MultiNode curr = head;

            while (curr.Right != null)
                curr = curr.Right;

            curr.Right = node;
        }

        public static LinkedListNode<int> Flatten(MultiNode head)
        {
            if (head == null) return null;

            Queue<MultiNode> q = new Queue<MultiNode>();
            LinkedList<int> result = new LinkedList<int>();

            q.Enqueue(head);

            while (q.Count > 0)
            {
                MultiNode temp = q.Dequeue();
                result.AddLast(temp.Data);

                if (temp.Down != null)
                    q.Enqueue(temp.Down);
                if (temp.Right != null)
                    q.Enqueue(temp.Right);
            }

            return result.First;
        }
    }
}
