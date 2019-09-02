using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace ListOfDepths
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

            var lst = ListsOfDepthsAlt(root);

            var lists = ListsOfDepths(root);

            var lists1 = ListsOfDepthsRecursive(root);

            Console.ReadLine();
        }

        private static List<LinkedList<int>> ListsOfDepthsAlt(TreeNode root)
        {
            if (root == null) return null;
            List<LinkedList<int>> lstResult = new List<LinkedList<int>>();
            PopulateLists(root, 0, lstResult);
            return lstResult;
        }

        private static void PopulateLists(TreeNode root, int level, List<LinkedList<int>> lstResult)
        {
            if (root != null)
            {
                if (lstResult.Count == level)
                {
                    LinkedList<int> lst = new LinkedList<int>();
                    lst.AddLast(root.Data);
                    lstResult.Add(lst);
                }
                else
                {
                    var lst = lstResult[level];
                    lst.AddLast(root.Data);
                    lstResult[level] = lst;
                }

                PopulateLists(root.Left, level + 1, lstResult);
                PopulateLists(root.Right, level + 1, lstResult);
            }
        }

        private static Dictionary<int, LinkedList<int>> ListsOfDepthsRecursive(TreeNode root)
        {
            if (root == null) return null;

            Dictionary<int, LinkedList<int>> resultMap = new Dictionary<int, LinkedList<int>>();
            int height = GetHeight(root);

            for (int i = 1; i <= height; i++)
            {
                resultMap.Add(i, GetListOfLevel(root, i));
            }

            return resultMap;
        }

        private static LinkedList<int> GetListOfLevel(TreeNode root, int level)
        {
            if (root == null) return null;

            LinkedList<int> list = new LinkedList<int>();
            if (level == 1)
                list.AddLast(root.Data);
            else if (level > 1)
            {
                var resultLeft = GetListOfLevel(root.Left, level - 1);
                var resultRight = GetListOfLevel(root.Right, level - 1);

                list = resultLeft;

                var current = resultRight.First;
                while (current != null)
                {
                    list.AddLast(current.Value);
                    current = current.Next;
                }
            }

            return list;
        }

        private static int GetHeight(TreeNode root)
        {
            if (root == null) return 0;
            else
            {
                int leftHeight = GetHeight(root.Left);
                int rightHeight = GetHeight(root.Right);

                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

        private static List<LinkedListNode<TreeNode>> ListsOfDepths(TreeNode root)
        {
            List<LinkedListNode<TreeNode>> lst = new List<LinkedListNode<TreeNode>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            lst.Add(new LinkedListNode<TreeNode>(root));

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                LinkedList<TreeNode> llTemp = new LinkedList<TreeNode>();

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                    llTemp.AddFirst(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                    llTemp.AddFirst(node.Right);
                }

                lst.Add(llTemp.First);
            }

            return lst;
        }
    }
}
