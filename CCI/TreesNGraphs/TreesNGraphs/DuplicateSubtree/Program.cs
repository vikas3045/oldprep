using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace DuplicateSubtree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            root.Right.Right = new TreeNode(2);
            root.Right.Right.Right = new TreeNode(5);
            root.Right.Right.Left = new TreeNode(4);

            HashSet<string> hashSet = new HashSet<string>();
            string str = DuplicateSubtree(root, hashSet);

            Console.WriteLine(str);

            Console.ReadLine();
        }

        private static string DuplicateSubtree(TreeNode root, HashSet<string> hashSet)
        {
            string s = "";

            // If current node is null, return marker
            if (root == null)
                return s + "$";

            // If left subtree has a duplicate subtree.
            string lStr = DuplicateSubtree(root.Left, hashSet);
            if (lStr == s)
                return s;

            // Do same for right subtree
            string rStr = DuplicateSubtree(root.Right, hashSet);
            if (rStr == s)
                return s;

            // Serialize current subtree
            s = s + root.Data + lStr + rStr;

            // If current subtree already exists in hash
            // table. [Note that size of a serialized tree
            // with single node is 3 as it has two marker
            // nodes.
            if (s.Length > 3 && hashSet.Contains(s))
                return "";

            hashSet.Add(s);

            return s;
        }
    }
}
