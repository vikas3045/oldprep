using System;
using System.Collections.Generic;
using System.Linq;
using Tree;

namespace CreateBST
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = { 1, 3, 4, 5, 8, 9 };

            TreeNode root = CreateBST(inputArr);

            Console.ReadLine();
        }

        public static TreeNode CreateBST(int[] inputArr)
        {
            return CreateBST(inputArr, 0, inputArr.Length - 1);
        }

        private static TreeNode CreateBST(int[] inputArr, int start, int end)
        {
            if (start <= end)
            {
                int mid = (start + end) / 2;

                TreeNode root = new TreeNode
                {
                    Data = inputArr[mid],
                    Left = CreateBST(inputArr, start, mid - 1),
                    Right = CreateBST(inputArr, mid + 1, end)
                };

                return root;
            }

            return null;
        }
    }
}
