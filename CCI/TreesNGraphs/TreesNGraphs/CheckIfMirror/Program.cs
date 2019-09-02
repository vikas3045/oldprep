using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace CheckIfMirror
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode nodeA = new TreeNode(1);
            nodeA.Left = new TreeNode(2);
            nodeA.Right = new TreeNode(3);

            TreeNode nodeB = new TreeNode(1);
            nodeB.Left = new TreeNode(3);
            nodeB.Right = new TreeNode(2);

            TreeNode root = new TreeNode(10);
            root.Left = nodeA;
            root.Right = nodeB;

            Console.Write(IsMirror(root));

            //Console.Write(CheckIfMirror(nodeA, nodeB));

            Console.ReadLine();
        }

        private static bool IsMirror(TreeNode root)
        {
            if (root == null)
                return true;

            return CheckIfMirror(root.Left, root.Right);
        }

        private static bool CheckIfMirror(TreeNode nodeA, TreeNode nodeB)
        {
            if (nodeA == null && nodeB == null)
                return true;
            else if (nodeA == null || nodeB == null)
                return false;

            if (nodeA.Data != nodeB.Data)
                return false;
            else
                return CheckIfMirror(nodeA.Left, nodeB.Right) && CheckIfMirror(nodeB.Left, nodeA.Right);
        }
    }
}
