using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace MaxDifferenceInNodeAndAncestor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> l = new List<int>();

            TreeNode root = new TreeNode();
            // Making above given diagram's binary tree
            root = new TreeNode(8);
            root.Left = new TreeNode(3);
            root.Left.Left = new TreeNode(1);
            root.Left.Right = new TreeNode(6);
            root.Left.Right.Left = new TreeNode(4);
            root.Left.Right.Right = new TreeNode(7);

            root.Right = new TreeNode(10);
            root.Right.Right = new TreeNode(14);
            root.Right.Right.Left = new TreeNode(13);

            Console.WriteLine(MaxDifferenceInNodeAndAncestor(root));

            Console.ReadLine();
        }

        private static int MaxDifferenceInNodeAndAncestor(TreeNode root)
        {
            Dictionary<TreeNode, int> hashMap = new Dictionary<TreeNode, int>();

            if (root == null) return int.MinValue;

            PopulateMinValues(root, hashMap);

            int max = int.MinValue;

            foreach (var pair in hashMap)
            {
                if (pair.Value != int.MaxValue)
                    max = Math.Max(max, pair.Key.Data - pair.Value);
            }

            return max;
        }

        private static void PopulateMinValues(TreeNode root, Dictionary<TreeNode, int> hashMap)
        {
            if (root == null) return;

            int leftMin = FindMinUtil(root.Left);
            int rightMin = FindMinUtil(root.Right);

            hashMap.Add(root, Math.Min(leftMin, rightMin));

            PopulateMinValues(root.Left, hashMap);
            PopulateMinValues(root.Right, hashMap);
        }

        private static int FindMinUtil(TreeNode root)
        {
            if (root == null)
                return int.MaxValue;

            int leftSubtree = FindMinUtil(root.Left);
            int rightSubtree = FindMinUtil(root.Right);

            return Math.Min(root.Data, Math.Min(leftSubtree, rightSubtree));
        }
    }
}
