using System;
using Tree;

namespace InOrderSuccessor
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNodeWithParent root = new TreeNodeWithParent(1);
            var node2 = new TreeNodeWithParent(2);
            var node3 = new TreeNodeWithParent(3);
            var node4 = new TreeNodeWithParent(4);
            var node5 = new TreeNodeWithParent(5);
            var node6 = new TreeNodeWithParent(6);
            var node7 = new TreeNodeWithParent(7);

            root.Left = node2;
            root.Right = node3;

            node2.Left = node4;
            node2.Right = node5;
            node2.Parent = root;

            node3.Left = node6;
            node3.Right = node7;
            node2.Parent = root;

            node4.Parent = node2;
            node5.Parent = node2;
            node6.Parent = node3;
            node7.Parent = node3;

            Console.Write(InOrderSuccessor(node2).Data);

            Console.ReadLine();
        }

        private static TreeNodeWithParent InOrderSuccessor(TreeNodeWithParent node)
        {
            if (node == null)
                return null;

            if (node.Right != null)
                return LeftMostChild(node.Right);
            else
            {
                TreeNodeWithParent child = node;
                TreeNodeWithParent parent = node.Parent;
                while (parent != null && parent.Left != child)
                {
                    child = parent;
                    parent = child.Parent;
                }

                return parent;
            }
        }

        private static TreeNodeWithParent LeftMostChild(TreeNodeWithParent root)
        {
            TreeNodeWithParent current = root;

            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }
    }
}
