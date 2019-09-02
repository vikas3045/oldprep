using System;
using Tree;

namespace MirrorImageMultiplication
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
            var node8 = new TreeNode(8);
            var node9 = new TreeNode(9);
            var node10 = new TreeNode(10);
            var node11 = new TreeNode(11);
            var node12 = new TreeNode(12);
            var node15 = new TreeNode(15);

            root.Left = node3;
            root.Right = node2;

            node3.Left = node7;
            node3.Right = node6;

            node2.Left = node5;
            node2.Right = node4;

            node7.Left = node11;
            node7.Right = node10;

            node6.Right = node15;

            node5.Left = node9;
            node5.Right = node8;

            node4.Right = node12;

            Console.WriteLine(MirrorImageMultiplication(root));

            Console.ReadLine();
        }

        private static int MirrorImageMultiplication(TreeNode root)
        {
            if (root == null)
                return 0;

            int height = GetHeight(root);
            int result = root.Data * root.Data;

            for (int i = 1; i <= height - 1; i++)
            {
                int[] leftSubtree = GetLevelWiseNodes(root.Left, i);
                int[] rightSubtree = GetLevelWiseNodes(root.Right, i);
                int n = leftSubtree.Length;
                for (int j = 0; j <= n - 1; j++)
                {
                    result += leftSubtree[j] * rightSubtree[(n - 1) - j];
                }
            }

            return result;
        }

        private static int[] GetLevelWiseNodes(TreeNode root, int level)
        {
            int maxNodesPossible = Convert.ToInt32(Math.Pow(2.0, level - 1));
            int[] result = new int[maxNodesPossible];

            if (level == 1 && root != null)
                result[0] = root.Data;
            else if (level > 1)
            {
                int[] leftSideNodes = GetLevelWiseNodes(root.Left, level - 1);
                int[] rightSideNodes = GetLevelWiseNodes(root.Right, level - 1);

                for (int i = 0; i <= leftSideNodes.Length - 1; i++)
                    result[i] = leftSideNodes[i];

                for (int i = 0; i <= leftSideNodes.Length - 1; i++)
                    result[leftSideNodes.Length + i] = rightSideNodes[i];
            }

            return result;
        }

        private static int GetHeight(TreeNode root)
        {
            if (root == null)
                return 0;
            else
            {
                int leftHeight = GetHeight(root.Left);
                int rightHeight = GetHeight(root.Right);

                return Math.Max(leftHeight + 1, rightHeight + 1);
            }
        }
    }
}
