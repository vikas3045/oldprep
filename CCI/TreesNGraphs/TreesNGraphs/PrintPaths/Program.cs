using System;
using System.Collections.Generic;
using Tree;

namespace PrintPaths
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

            PrintPaths(root);

            foreach (var path in GetAllPaths(root))
            {
                foreach (var node in path)
                    Console.Write(node + " --> ");
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public static List<List<int>> GetAllPaths(TreeNode root)
        {
            List<List<int>> lstResult = new List<List<int>>();
            List<int> lstCurrPath = new List<int>();
            PopulatePaths(root, lstCurrPath, lstResult);
            return lstResult;
        }

        private static void PopulatePaths(TreeNode root, List<int> lstCurrPath, List<List<int>> lstResult)
        {
            if (root == null) return;

            lstCurrPath.Add(root.Data);

            if (root.Left == null && root.Right == null)
            {
                lstResult.Add(lstCurrPath);
                return;
            }

            List<int> subPathLeft = new List<int>(lstCurrPath);
            PopulatePaths(root.Left, subPathLeft, lstResult);

            List<int> subPathRight = new List<int>(lstCurrPath);
            PopulatePaths(root.Right, subPathRight, lstResult);
        }

        private static void PrintPaths(TreeNode root)
        {
            int[] path = new int[256];
            PrintPaths(root, path, 0);
        }

        private static void PrintPaths(TreeNode root, int[] path, int pathLength)
        {
            if (root == null)
                return;

            // append this node to the path array
            path[pathLength] = root.Data;
            pathLength++;

            // it's a leaf, so print the path that led to here
            if (root.Left == null && root.Right == null)
            {
                PrintArray(path, pathLength);
            }
            else // otherwise try both subtrees
            {
                PrintPaths(root.Left, path, pathLength);
                PrintPaths(root.Right, path, pathLength);
            }
        }

        private static void PrintArray(int[] path, int pathLength)
        {
            for (int i = 0; i < pathLength; i++)
                Console.Write((i == pathLength - 1) ? path[i] + "" : path[i] + " --> ");
            Console.WriteLine();
        }
    }
}
