using System;
using System.Collections.Generic;
using Tree;

namespace VerticalOrderTraversal
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

            //VerticalOrderTraversal(root);

            PrintVerticalOrder(root);

            Console.ReadLine();
        }

        private static void PrintVerticalOrder(TreeNode root)
        {
            SortedDictionary<int, List<int>> sDicResult = new SortedDictionary<int, List<int>>();
            int hd = 0;

            GetVerticalOrder(root, hd, sDicResult);

            //Print
            foreach (var resultSet in sDicResult)
            {
                foreach (var node in resultSet.Value)
                    Console.Write(node + " ");

                Console.WriteLine();
            }
        }

        private static void GetVerticalOrder(TreeNode root, int hd, SortedDictionary<int, List<int>> sDicResult)
        {
            if (root == null) return;


            if (sDicResult.ContainsKey(hd))
            {
                List<int> lstHD = sDicResult[hd];
                lstHD.Add(root.Data);

                sDicResult[hd] = lstHD;
            }
            else
            {
                List<int> lstHD = new List<int> { root.Data };
                sDicResult.Add(hd, lstHD);
            }

            // Store nodes in left subtree
            GetVerticalOrder(root.Left, hd - 1, sDicResult);

            // Store nodes in right subtree
            GetVerticalOrder(root.Right, hd + 1, sDicResult);
        }
    }
}
