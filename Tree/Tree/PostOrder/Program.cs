using Stack;
using System;
using Tree;

namespace PostOrder
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

            Console.WriteLine(Size(root));

            //var watch = System.Diagnostics.Stopwatch.StartNew();

            //Console.Write("Iterative: ");
            //PostOrderIterative(root);

            //watch.Stop();
            //Console.Write(" Time: " + watch.ElapsedMilliseconds + " ms");

            //Console.WriteLine();

            //watch.Restart();

            //Console.Write("Recursive: ");
            //PostOrderRecursive(root);

            //watch.Stop();
            //Console.Write(" Time: " + watch.ElapsedMilliseconds + " ms");

            Console.ReadLine();
        }

        private static void PostOrderRecursive(BinaryTreeNode root)
        {
            if (root != null)
            {
                PostOrderRecursive(root.Left);
                PostOrderRecursive(root.Right);
                ProcessNode(root);
            }
        }

        private static void PostOrderIterative(BinaryTreeNode root)
        {
            if (root == null)
                return;

            LinkedStack<BinaryTreeNode> stack = new LinkedStack<BinaryTreeNode>();
            LinkedStack<BinaryTreeNode> stackToReverse = new LinkedStack<BinaryTreeNode>();

            stack.Push(root);

            while (!stack.IsEmpty())
            {
                var currentNode = stack.Pop();

                stackToReverse.Push(currentNode);

                if (currentNode.Left != null)
                    stack.Push(currentNode.Left);

                if (currentNode.Right != null)
                    stack.Push(currentNode.Right);
            }

            while (!stackToReverse.IsEmpty())
            {
                ProcessNode(stackToReverse.Pop());
            }
        }

        private static void ProcessNode(BinaryTreeNode node)
        {
            Console.Write(node.Data + " ");
        }

        private static bool IsNodePresent(BinaryTreeNode root, int data)
        {
            if (root != null)
                return root.Data == data || IsNodePresent(root.Left, data) || IsNodePresent(root.Right, data);

            return false;
        }

        private static int Size(BinaryTreeNode root)
        {
            if (root != null)
            {
                return 1 + Size(root.Left) + Size(root.Right);
            }
            return 0;
        }
    }
}
