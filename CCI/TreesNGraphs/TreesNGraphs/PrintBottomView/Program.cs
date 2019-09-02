using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace PrintBottomView
{
    class Program
    {
        static void Main(string[] args)
        {

            TreeNode root = new TreeNode(10);
            var node2 = new TreeNode(9);
            var node3 = new TreeNode(11);
            var node4 = new TreeNode(8);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(12);

            root.Left = node2;
            root.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node3.Left = node6;
            node3.Right = node7;

            PrintBottomView(root);

            Console.ReadLine();
        }

        private static void PrintBottomView(TreeNode root)
        {
            if (root != null)
            {
                if (root.Left == null && root.Right == null)
                    Console.Write(root.Data + " ");

                PrintBottomView(root.Left);
                PrintBottomView(root.Right);
            }
        }
    }
}
