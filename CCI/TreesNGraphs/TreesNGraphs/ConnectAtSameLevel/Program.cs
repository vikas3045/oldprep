using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace ConnectAtSameLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNodeWithNext root = new TreeNodeWithNext(1);
            var node2 = new TreeNodeWithNext(2);
            var node3 = new TreeNodeWithNext(3);
            var node4 = new TreeNodeWithNext(4);
            var node5 = new TreeNodeWithNext(5);
            var node6 = new TreeNodeWithNext(6);
            var node7 = new TreeNodeWithNext(7);

            root.Left = node2;
            root.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node3.Left = node6;
            node3.Right = node7;

            ConnectAtSameLevel(root);

            Console.ReadLine();
        }

        private static void ConnectAtSameLevel(TreeNodeWithNext root)
        {
            if (root == null) return;

            Queue<TreeNodeWithNext> q = new Queue<TreeNodeWithNext>();
            q.Enqueue(root);
            q.Enqueue(null);

            while (q.Count > 0)
            {
                TreeNodeWithNext current = q.Dequeue();

                if (current != null)
                {
                    current.Next = q.Peek();

                    if (current.Left != null)
                        q.Enqueue(current.Left);
                    if (current.Right != null)
                        q.Enqueue(current.Right);
                }
                else
                {
                    if (q.Count > 0)
                    {
                        q.Enqueue(null);
                    }
                }
            }
        }
    }
}
