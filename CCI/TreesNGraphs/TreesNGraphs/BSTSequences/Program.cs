using System;
using System.Collections.Generic;
using Tree;

namespace BSTSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(4);
            var node2 = new TreeNode(2);
            var node6 = new TreeNode(6);
            root.Left = node2;
            root.Right = node6;
            root.Left.Left = new TreeNode(1);
            root.Right.Left = new TreeNode(5);


            var result = GetBSTSequences(root);

            Console.ReadLine();
        }

        private static List<LinkedList<int>> GetBSTSequences(TreeNode root)
        {
            List<LinkedList<int>> lstResult = new List<LinkedList<int>>();

            if (root == null)
            {
                lstResult.Add(new LinkedList<int>());
                return lstResult;
            }

            LinkedList<int> prefix = new LinkedList<int>();
            prefix.AddLast(root.Data);

            // Recurse on left and right subtrees
            List<LinkedList<int>> lstLeftSeq = GetBSTSequences(root.Left);
            List<LinkedList<int>> lstRightSeq = GetBSTSequences(root.Right);

            // Weave together each list from the left and right sides
            foreach (LinkedList<int> left in lstLeftSeq)
            {
                foreach (LinkedList<int> right in lstRightSeq)
                {
                    List<LinkedList<int>> lstWeaved = new List<LinkedList<int>>();
                    WeaveLists(left, right, lstWeaved, prefix);
                    lstResult.AddRange(lstWeaved);
                }
            }

            return lstResult;
        }

        private static void WeaveLists(LinkedList<int> first, LinkedList<int> second, List<LinkedList<int>> lstResult, LinkedList<int> prefix)
        {
            if (first.Count == 0 || second.Count == 0)
            {
                LinkedList<int> result = new LinkedList<int>(prefix);

                foreach (var item in first)
                    result.AddLast(item);

                foreach (var item in second)
                    result.AddLast(item);

                lstResult.Add(result);
                return;
            }

            int headFirst = first.First.Value;
            first.RemoveFirst();
            prefix.AddLast(headFirst);
            WeaveLists(first, second, lstResult, prefix);
            prefix.RemoveLast();
            first.AddFirst(headFirst);

            int headSecond = second.First.Value;
            second.RemoveFirst();
            prefix.AddLast(headSecond);
            WeaveLists(first, second, lstResult, prefix);
            prefix.RemoveLast();
            second.AddFirst(headSecond);
        }
    }
}
