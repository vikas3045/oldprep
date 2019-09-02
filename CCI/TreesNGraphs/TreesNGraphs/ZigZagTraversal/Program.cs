using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace ZigZagTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(7);

            root.Left = node2;
            root.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node3.Left = node6;
            node3.Right = node7;

            Traverse(root);
            Console.WriteLine();
            ZigZagTraversal(root);

            Console.ReadLine();
        }

        public static void Traverse(TreeNode root)
        {
            if (root == null) return;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(null);
            bool isLeftToRight = false;
            List<int> lstCurrent = new List<int>();
            while (q.Count > 0)
            {
                var current = q.Dequeue();

                if (current != null)
                {
                    lstCurrent.Add(current.Data);

                    if (current.Left != null) q.Enqueue(current.Left);
                    if (current.Right != null) q.Enqueue(current.Right);
                }
                else
                {
                    if (q.Count > 0)
                    {
                        q.Enqueue(null);
                    }

                    if (isLeftToRight)
                        lstCurrent.Reverse();

                    foreach (var ele in lstCurrent)
                        Console.Write(ele + " ");

                    isLeftToRight = !isLeftToRight;
                    lstCurrent.Clear();
                }
            }
        }
    }
}
