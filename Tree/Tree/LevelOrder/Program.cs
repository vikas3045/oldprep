using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace LevelOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeNode root = new BinaryTreeNode(1);
            var node2 = new BinaryTreeNode(2);
            var node3 = new BinaryTreeNode(3);
            var node4 = new BinaryTreeNode(4);
            var node5 = new BinaryTreeNode(5);
            var node6 = new BinaryTreeNode(6);
            var node7 = new BinaryTreeNode(7);

            root.Left = node2;
            root.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node3.Left = node6;
            node3.Right = node7;

            LevelOrder(root);
            Console.WriteLine();
            LevelOrderRecursive(root);

            Console.ReadLine();
        }

        private static void LevelOrder(BinaryTreeNode root)
        {
            if (root == null)
                return;

            Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                BinaryTreeNode current = queue.Dequeue();
                ProcessNode(current);
                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }
        }

        public static void LevelOrderRecursive(BinaryTreeNode root)
        {
            int height = GetHeightOfTree(root);
            for (int i = 1; i <= height; i++)
                PrintGivenLevel(root, i);
        }

        private static void PrintGivenLevel(BinaryTreeNode root, int level)
        {
            if (root == null) return;

            if (level == 1)
                Console.Write(root.Data + " ");
            else if (level > 1)
            {
                PrintGivenLevel(root.Left, level - 1);
                PrintGivenLevel(root.Right, level - 1);
            }
        }

        private static int GetHeightOfTree(BinaryTreeNode root)
        {
            if (root == null) return 0;
            else
            {
                int leftHeight = GetHeightOfTree(root.Left);
                int rightHeight = GetHeightOfTree(root.Right);

                return Math.Max(leftHeight + 1, rightHeight + 1);
            }
        }

        static void ProcessNode(BinaryTreeNode node)
        {
            Console.Write(node.Data + " ");
        }
    }
}
