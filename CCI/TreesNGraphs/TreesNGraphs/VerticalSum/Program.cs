using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace VerticalSum
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

            VerticalSum(root);

            Console.ReadLine();
        }

        private static void VerticalSum(TreeNode root)
        {
            if (root == null) return;

            SortedDictionary<int, int> dicVerticalSum = new SortedDictionary<int, int>();

            VerticalSumHelper(root, 0, dicVerticalSum);

            foreach (var pair in dicVerticalSum)
            {
                Console.Write(pair.Value + " ");
            }
        }

        private static void VerticalSumHelper(TreeNode root, int curLevel, SortedDictionary<int, int> dicVerticalSum)
        {
            if (root == null) return;

            if (!dicVerticalSum.ContainsKey(curLevel))
                dicVerticalSum.Add(curLevel, root.Data);
            else
                dicVerticalSum[curLevel] += root.Data;

            VerticalSumHelper(root.Left, curLevel - 1, dicVerticalSum);
            VerticalSumHelper(root.Right, curLevel + 1, dicVerticalSum);
        }
    }
}
