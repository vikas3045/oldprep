using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace FindAllDuplicateSubtrees
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = null;
            root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Right.Left = new TreeNode(2);
            root.Right.Left.Left = new TreeNode(4);
            root.Right.Right = new TreeNode(4);

            PrintAllDups(root);

            Console.ReadLine();
        }

        private static void PrintAllDups(TreeNode root)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            InOrder(root, map);
        }

        private static string InOrder(TreeNode root, Dictionary<string, int> map)
        {
            if (root == null)
                return "";

            String str = "(";
            str += InOrder(root.Left, map);
            str += root.Data;
            str += InOrder(root.Right, map);
            str += ")";

            // Subtree already present (Note that we use
            // HashMap instead of HashSet
            // because we want to print multiple duplicates
            // only once, consider example of 4 in above
            // subtree, it should be printed only once.       
            if (map.ContainsKey(str) && map[str] == 1)
                Console.Write(root.Data + " ");

            if (map.ContainsKey(str))
                map[str] += 1;
            else
                map.Add(str, 1);

            return str;
        }
    }
}
