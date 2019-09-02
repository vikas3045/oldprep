using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heap;
using Tree;

namespace LevelsInSortedOrder
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

            PrintLevelsInSortedOrder(root);

            Console.ReadLine();
        }

        public static void PrintLevelsInSortedOrder(TreeNode root)
        {
            int height = GetHeight(root);
            for (int i = 1; i <= height; i++)
            {
                Heap.Heap minHeap = GetLevelWiseNodes(root, i);
                while (minHeap.count > 0)
                {
                    Console.Write(minHeap.Delete() + " ");
                }
            }
        }

        private static Heap.Heap GetLevelWiseNodes(TreeNode root, int level)
        {
            if (root == null) return null;

            Heap.Heap heapResult = new Heap.Heap(Convert.ToInt32(Math.Pow(2, level - 1)), Heap.Heap.Type.Min);
            if (level == 1)
                heapResult.Insert(root.Data);
            else if (level > 1)
            {
                Heap.Heap subResult1 = GetLevelWiseNodes(root.Left, level - 1);
                Heap.Heap subResult2 = GetLevelWiseNodes(root.Right, level - 1);

                while (subResult1.count > 0)
                    heapResult.Insert(subResult1.Delete());
                while (subResult2.count > 0)
                    heapResult.Insert(subResult2.Delete());
            }

            return heapResult;
        }

        private static int GetHeight(TreeNode root)
        {
            if (root == null)
                return 0;
            else
            {
                int leftHeight = GetHeight(root.Left);
                int rightHeight = GetHeight(root.Right);

                return Math.Max(leftHeight + 1, rightHeight + 1);
            }
        }
    }
}
