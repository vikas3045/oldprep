using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace MaxSumPath
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(10);
            var node2 = new TreeNode(2);
            var node10 = new TreeNode(10);
            var node20 = new TreeNode(20);
            var node1 = new TreeNode(1);
            var nodeM25 = new TreeNode(-25);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);

            root.Left = node2;
            root.Right = node10;

            node2.Left = node20;
            node2.Right = node1;

            node10.Right = nodeM25;

            nodeM25.Left = node3;
            nodeM25.Right = node4;
            Result result = new Result();
            result.val = int.MinValue;
            MaxSumPath(root, result);
            Console.WriteLine(result.val);

            Console.ReadLine();
        }

        private static int MaxSumPath(TreeNode root, Result maxPathSum)
        {
            if (root == null)
                return 0;

            int leftSubtreeMaxSumPath = MaxSumPath(root.Left, maxPathSum);
            int rightSubtreeMaxSumPath = MaxSumPath(root.Right, maxPathSum);

            // Max path considering current node as subtree of the actual solution
            // leftsubtree + root, rightsubtree + root, root
            int maxSingleSubtree = Math.Max(leftSubtreeMaxSumPath + root.Data, rightSubtreeMaxSumPath + root.Data);
            int maxSingle = Math.Max(maxSingleSubtree, root.Data);

            // Max path considering the current node as root of the actual solution
            int maxCompleteTree = Math.Max(maxSingle, leftSubtreeMaxSumPath + rightSubtreeMaxSumPath + root.Data);

            maxPathSum.val = Math.Max(maxPathSum.val, maxCompleteTree);

            return maxSingle;
        }
    }

    class Result
    {
        public int val;
    }
}
