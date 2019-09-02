using System;
using Tree;

namespace IsBalanced
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

            Console.Write(IsBalanced(root));

            Console.ReadLine();
        }

        private static bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;

            int leftHeight = GetHeight(root.Left);
            int rightHeight = GetHeight(root.Right);

            if (Math.Abs(leftHeight - rightHeight) > 1)
                return false;
            else
                return IsBalanced(root.Left) && IsBalanced(root.Right);
        }

        private static int GetHeight(TreeNode root)
        {
            if (root == null)
                return 0;
            else
            {
                int leftHeight = GetHeight(root.Left);
                int rightHeight = GetHeight(root.Right);

                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }
    }
}
