using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace BinaryToDLL
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

            TreeNode head = BinaryToDLL(root);

            Console.ReadLine();
        }

        private static TreeNode BinaryToDLL(TreeNode root)
        {
            if (root == null)
                return null;

            TreeNode head = null;
            TreeNode prev = null;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;

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

                    if (prev != null)
                    {
                        prev.Right = current;
                        current.Left = prev;
                    }
                    else
                    {
                        head = current;
                        current.Left = prev;
                    }

                    prev = current;
                    current = current.Right;
                }
            }

            return head;
        }
    }
}
