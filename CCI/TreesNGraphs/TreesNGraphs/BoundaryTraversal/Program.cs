using System;
using Tree;

namespace BoundaryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(20)
            {
                Left = new TreeNode(8),
                Right = new TreeNode(22)
            };
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(12)
            {
                Left = new TreeNode(10),
                Right = new TreeNode(14)
            };
            root.Right.Right = new TreeNode(25);

            BoundaryTraversal(root);

            Console.ReadLine();
        }

        private static void BoundaryTraversal(TreeNode root)
        {
            if (root != null)
            {
                VisitNode(root);

                PrintLeftBoundary(root.Left);
                PrintLeafNodes(root);
                PrintRightBoundary(root.Right);
            }
        }

        private static void PrintLeftBoundary(TreeNode root)
        {
            if (root != null)
            {
                if (root.Left != null || root.Right != null)
                    VisitNode(root);

                if (root.Left != null)
                    PrintLeftBoundary(root.Left);
                else if (root.Right != null)
                    PrintLeftBoundary(root.Right);
            }
        }

        private static void PrintRightBoundary(TreeNode root)
        {
            if (root != null)
            {
                if (root.Right != null)
                    PrintRightBoundary(root.Right);
                else if (root.Left != null)
                    PrintRightBoundary(root.Left);

                if (root.Left != null || root.Right != null)
                    VisitNode(root);
            }
        }

        private static void PrintLeafNodes(TreeNode root)
        {
            if (root != null)
            {
                if (root.Left == null && root.Right == null)
                    VisitNode(root);

                PrintLeafNodes(root.Left);
                PrintLeafNodes(root.Right);
            }
        }

        private static void VisitNode(TreeNode node)
        {
            Console.Write(node.Data + " ");
        }
    }
}
