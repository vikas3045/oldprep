using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace SubtreeWithSpecificSum
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(5);
            root.Left = new TreeNode(-10);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(9);
            root.Left.Right = new TreeNode(8);
            root.Right.Left = new TreeNode(-4);
            root.Right.Right = new TreeNode(7);

            Console.WriteLine(SubtreeWithSpecificSum(root, 7));

            Console.ReadLine();
        }

        private static int SubtreeWithSpecificSum(TreeNode root, int x)
        {
            if (root == null)
                return 0;

            int result = 0;

            if (SumTree(root) == x)
                result++;

            result += SubtreeWithSpecificSum(root.Left, x);
            result += SubtreeWithSpecificSum(root.Right, x);

            return result;
        }

        private static int SumTree(TreeNode root)
        {
            if (root == null)
                return 0;

            return root.Data + SumTree(root.Left) + SumTree(root.Right);
        }
    }
}
