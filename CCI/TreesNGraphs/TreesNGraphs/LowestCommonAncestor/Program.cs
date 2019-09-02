using System;
using Tree;

namespace LowestCommonAncestor
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

            Console.Write(LowestCommonAncestor(root, node7, node6).Data);

            Console.ReadLine();
        }

        private static TreeNode LowestCommonAncestor(TreeNode root, TreeNode nodeA, TreeNode nodeB)
        {
            if (root == null)
                return null;

            ///// optimized way....it reduces the number of searches
            //// change starts
            //int a = IsPresentAlt(root, nodeA);
            //int b = IsPresentAlt(root, nodeB);

            //if (a == 0 || b == 0)
            //    return null;

            //if (a != b)
            //{
            //    return root;
            //}
            //else
            //{
            //    if (a == 1)
            //    {
            //        return LowestCommonAncestor(root.Left, nodeA, nodeB);
            //    }
            //    else
            //    {
            //        return LowestCommonAncestor(root.Right, nodeA, nodeB);
            //    }
            //}
            //// change ends


            if (!IsPresent(root, nodeA) || !IsPresent(root, nodeB))
                return null;

            if (root == nodeA || root == nodeB)
                return root;

            bool isNodeAInLeft = IsPresent(root.Left, nodeA);
            bool isNodeBInLeft = IsPresent(root.Left, nodeB);

            if (isNodeAInLeft != isNodeBInLeft)
                return root;
            else if (isNodeAInLeft && isNodeBInLeft)
                return LowestCommonAncestor(root.Left, nodeA, nodeB);
            else
                return LowestCommonAncestor(root.Right, nodeA, nodeB);
        }

        private static bool IsPresent(TreeNode root, TreeNode node)
        {
            if (root == null)
                return false;

            if (root == node)
                return true;

            return IsPresent(root.Left, node) || IsPresent(root.Right, node);
        }

        private static int IsPresentAlt(TreeNode root, TreeNode node)
        {
            if (root == null)
                return 0;
            else if (root == node)
                return 1;

            int left = IsPresentAlt(root.Left, node);
            if (left > 0)
                return 2;

            int right = IsPresentAlt(root.Right, node);
            if (right > 0)
                return 3;

            return 0;
        }
    }
}
