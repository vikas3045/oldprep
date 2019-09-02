using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace TiltTree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(4);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(9);
            root.Left.Left = new TreeNode(3);
            root.Left.Right = new TreeNode(5);
            root.Right.Right = new TreeNode(7);

            Console.WriteLine(TiltTree(root));

            Console.ReadLine();
        }

        private static int TiltTree(TreeNode root)
        {
            if (root == null) return 0;
            return TiltNode(root) + TiltTree(root.Left) + TiltTree(root.Right);
        }

        private static int TiltNode(TreeNode node)
        {
            if (node == null) return 0;

            int leftSum = Sum(node.Left);
            int rightSum = Sum(node.Right);

            return Math.Abs(leftSum - rightSum);
        }

        private static int Sum(TreeNode node)
        {
            if (node == null) return 0;
            return node.Data + Sum(node.Left) + Sum(node.Right);
        }
    }
}
