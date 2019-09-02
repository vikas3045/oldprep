using System;
using Tree;

namespace AddGreaterToEveryNode
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(50);
            var node2 = new TreeNode(30);
            var node3 = new TreeNode(70);
            var node4 = new TreeNode(20);
            var node5 = new TreeNode(40);
            var node6 = new TreeNode(60);
            var node7 = new TreeNode(80);

            root.Left = node2;
            root.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node3.Left = node6;
            node3.Right = node7;

            GreaterVal greater = new GreaterVal();
            AddGreaterToEveryNode(root, greater);

            Console.ReadLine();
        }

        private static void AddGreaterToEveryNode(TreeNode root, GreaterVal greater)
        {
            if (root == null) return;

            AddGreaterToEveryNode(root.Right, greater);

            root.Data += greater.Val;
            greater.Val = root.Data;

            AddGreaterToEveryNode(root.Left, greater);
        }
    }

    class GreaterVal
    {
        public int Val { get; set; }
    }
}
