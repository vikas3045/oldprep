using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace BinaryTreeToDLL
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(10)
            {
                Left = new TreeNode(12),
                Right = new TreeNode(15)
            };
            root.Left.Left = new TreeNode(25);
            root.Left.Right = new TreeNode(30);
            root.Right.Left = new TreeNode(36);

            TreeNode result = BinaryTreeToDLL(root);

            Console.ReadLine();
        }

        private static TreeNode BinaryTreeToDLL(TreeNode root)
        {
            if (root == null) return null;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;
            TreeNode prev = null;
            TreeNode resultHead = null;

            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();

                    if (resultHead == null)
                    {
                        resultHead = current;
                        resultHead.Left = prev;
                    }
                    else
                    {
                        prev.Right = current;
                        current.Left = prev;
                    }
                    prev = current;

                    current = current.Right;
                }
            }

            return resultHead;
        }

        public static TreeNode BinaryToD(TreeNode root)
        {
            if (root == null) return null;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;
            TreeNode prev = null;
            TreeNode resultHead = null;
            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();

                    if (resultHead == null)
                    {
                        prev.Right = current;
                        current.Left = prev;
                        resultHead = current;
                    }
                    else
                    {
                        prev.Right = current;
                        current.Left = prev;
                    }

                    current = current.Right;
                }
            }

            return resultHead;
        }
    }
}
