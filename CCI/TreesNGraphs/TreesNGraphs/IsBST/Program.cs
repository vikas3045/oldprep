﻿using System;
using Tree;

namespace IsBST
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(10);
            var node2 = new TreeNode(9);
            var node3 = new TreeNode(11);
            var node4 = new TreeNode(8);
            //var node5 = new TreeNode(5);
            //var node6 = new TreeNode(6);
            var node7 = new TreeNode(12);

            root.Left = node2;
            root.Right = node3;

            node2.Left = node4;
            //node2.Right = node5;

            //node3.Left = node6;
            node3.Right = node7;

            Console.WriteLine(IsBST(root));

            Console.ReadLine();
        }

        public static bool IsBST(TreeNode root)
        {
            return IsBSTUtil(root, int.MinValue, int.MaxValue);
        }

        private static bool IsBSTUtil(TreeNode root, int minValue, int maxValue)
        {
            if (root == null) return true;

            if (root.Data < minValue || root.Data > maxValue)
                return false;

            return IsBSTUtil(root.Left, minValue, root.Data) && IsBSTUtil(root.Right, root.Data, maxValue);
        }
    }
}
