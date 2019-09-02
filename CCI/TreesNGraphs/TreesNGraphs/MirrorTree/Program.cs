﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace MirrorTree
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

            var mirror = MirrorTree(root);

            Console.ReadLine();
        }

        public static TreeNode MirrorTree(TreeNode root)
        {
            if (root == null) return null;

            TreeNode mirror = new TreeNode(root.Data);
            mirror.Left = MirrorTree(root.Right);
            mirror.Right = MirrorTree(root.Left);
            return mirror;
        }
    }
}
