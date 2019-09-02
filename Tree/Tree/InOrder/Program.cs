using Stack;
using System;
using System.Collections.Generic;
using Tree;

namespace InOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeNode root = new BinaryTreeNode(1);
            root.Left = new BinaryTreeNode(2);
            root.Right = new BinaryTreeNode(3);
            root.Left.Left = new BinaryTreeNode(4);
            root.Left.Right = new BinaryTreeNode(10);
            root.Left.Left.Left = new BinaryTreeNode(7);
            root.Left.Left.Right = new BinaryTreeNode(5);

            root.Right.Left = new BinaryTreeNode(7);
            root.Right.Right = new BinaryTreeNode(10);
            root.Right.Left.Left = new BinaryTreeNode(8);
            root.Right.Left.Right = new BinaryTreeNode(9);
            root.Right.Right.Right = new BinaryTreeNode(11);

            //BinaryTreeNode root = new BinaryTreeNode(50);
            //var node2 = new BinaryTreeNode(2);
            //var node3 = new BinaryTreeNode(3);
            //var node4 = new BinaryTreeNode(4);
            //var node5 = new BinaryTreeNode(5);
            //var node6 = new BinaryTreeNode(6);
            //var node7 = new BinaryTreeNode(7);

            //root.Left = node2;
            //root.Right = node3;

            //node2.Left = node4;
            //node2.Right = node5;

            //node3.Left = node6;
            //node3.Right = node7;

            //var watch = System.Diagnostics.Stopwatch.StartNew();
            //Console.WriteLine(GetMaximumRecursive(root));
            //watch.Stop();
            //Console.Write(" Time: " + watch.ElapsedMilliseconds + " ms");

            //watch.Restart();
            //Console.WriteLine(GetMaximumIterative(root));
            //watch.Stop();
            //Console.Write(" Time: " + watch.ElapsedMilliseconds + " ms");

            var watch = System.Diagnostics.Stopwatch.StartNew();

            Console.Write("Recursive: ");
            InOrderRecursive(root);

            watch.Stop();
            Console.Write(" Time: " + watch.ElapsedMilliseconds + " ms");

            Console.WriteLine();

            watch.Restart();

            Console.Write("Iterative: ");
            InOrderIterative(root);

            watch.Stop();
            Console.Write(" Time: " + watch.ElapsedMilliseconds + " ms");

            Console.ReadLine();
        }

        private static void InOrderRecursive(BinaryTreeNode root)
        {
            if (root != null)
            {
                InOrderRecursive(root.Left);
                ProcessNode(root);
                InOrderRecursive(root.Right);
            }
        }

        private static void InOrderIterative(BinaryTreeNode root)
        {
            if (root == null)
                return;

            Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
            BinaryTreeNode currentNode = root;

            while (stack.Count > 0 || currentNode != null)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = stack.Pop();
                    ProcessNode(currentNode);
                    currentNode = currentNode.Right;
                }
            }
        }

        private static void ProcessNode(BinaryTreeNode root)
        {
            Console.Write(root.Data + " ");
        }

        private static int GetMaximumIterative(BinaryTreeNode root)
        {
            int maxValue = int.MinValue;
            if (root == null)
                return maxValue;

            Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
            BinaryTreeNode currentNode = root;

            while (stack.Count != 0 || currentNode != null)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);

                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = stack.Pop();

                    if (currentNode.Data > maxValue)
                    {
                        maxValue = currentNode.Data;
                    }

                    currentNode = currentNode.Right;
                }
            }

            return maxValue;
        }

        private static int GetMaximumRecursive(BinaryTreeNode root)
        {
            int maxValue = int.MinValue;
            if (root != null)
            {
                int leftSubtreeMax = GetMaximumRecursive(root.Left);
                if (leftSubtreeMax > maxValue)
                    maxValue = leftSubtreeMax;

                if (root.Data > maxValue)
                    maxValue = root.Data;

                int rightSubtreeMax = GetMaximumRecursive(root.Right);
                if (rightSubtreeMax > maxValue)
                    maxValue = rightSubtreeMax;
            }
            return maxValue;
        }
    }
}
