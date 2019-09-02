using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace LevelOrderToBST
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = { 7, 4, 12, 3, 6, 8, 1, 5, 10 };
            TreeNode root = CreateBST(inputArr);

            Console.ReadLine();
        }

        private static TreeNode CreateBST(int[] inputArr)
        {
            if (inputArr.Length == 0)
                return null;

            TreeNode root = new TreeNode(inputArr[0]);

            for (int i = 1; i <= inputArr.Length - 1; i++)
                InsertToBSTIterative(root, inputArr[i]);

            return root;
        }

        private static TreeNode InsertToBST(TreeNode root, int node)
        {
            if (root == null)
                return new TreeNode(node);

            if (node < root.Data)
                root.Left = InsertToBST(root.Left, node);
            else
                root.Right = InsertToBST(root.Right, node);

            return root;
        }

        private static TreeNode InsertToBSTIterative(TreeNode root, int node)
        {
            TreeNode current = root;

            while (current != null)
            {
                if (node < current.Data)
                {
                    if (current.Left != null)
                        current = current.Left;
                    else
                    {
                        current.Left = new TreeNode(node);
                        break;
                    }
                }
                else
                {
                    if (current.Right != null)
                        current = current.Right;
                    else
                    {
                        current.Right = new TreeNode(node);
                        break;
                    }
                }
            }

            return root;
        }
    }
}
