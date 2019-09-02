using Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace PreOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeNode root = new BinaryTreeNode(50);
            var node2 = new BinaryTreeNode(2);
            var node3 = new BinaryTreeNode(3);
            var node4 = new BinaryTreeNode(10);
            var node5 = new BinaryTreeNode(5);
            var node6 = new BinaryTreeNode(6);
            var node7 = new BinaryTreeNode(7);

            root.Left = node2;
            root.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node3.Left = node6;
            node3.Right = node7;

            Console.WriteLine(GetMaximum(root));

            //var watch = System.Diagnostics.Stopwatch.StartNew();

            //Console.Write("Recursive: ");
            //PreOrderRecursive(root);

            //watch.Stop();
            //Console.Write(" Time: " + watch.ElapsedMilliseconds + " ms");

            //Console.WriteLine();

            //watch.Restart();

            //Console.Write("Iterative: ");
            //PreOrderIterative(root);

            //watch.Stop();
            //Console.Write(" Time: " + watch.ElapsedMilliseconds + " ms");

            Console.ReadLine();
        }

        static void PreOrderRecursive(BinaryTreeNode root)
        {
            if (root != null)
            {
                ProcessNode(root);
                PreOrderRecursive(root.Left);
                PreOrderRecursive(root.Right);
            }
        }

        static void PreOrderIterative(BinaryTreeNode root)
        {
            if (root == null)
                return;

            LinkedStack<BinaryTreeNode> stack = new LinkedStack<BinaryTreeNode>();
            stack.Push(root);

            while (!stack.IsEmpty())
            {
                var currentNode = stack.Pop();

                ProcessNode(currentNode);

                if (currentNode.Right != null)
                    stack.Push(currentNode.Right);

                if (currentNode.Left != null)
                    stack.Push(currentNode.Left);
            }
        }

        static void ProcessNode(BinaryTreeNode node)
        {
            Console.Write(node.Data + " ");
        }

        static int GetMaximum(BinaryTreeNode root)
        {
            int maxValue = int.MinValue;
            if (root != null)
            {
                if (root.Data > maxValue)
                    maxValue = root.Data;

                int maxLeftSubtree = GetMaximum(root.Left);
                if (maxLeftSubtree > maxValue)
                    maxValue = maxLeftSubtree;

                int maxRightSubtree = GetMaximum(root.Right);
                if (maxRightSubtree > maxValue)
                    maxValue = maxRightSubtree;
            }
            return maxValue;
        }
    }
}
