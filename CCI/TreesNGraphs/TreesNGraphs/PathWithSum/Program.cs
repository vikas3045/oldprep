using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace PathWithSum
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreeNode root = new TreeNode(1);
            //root.Left = new TreeNode(3);
            //root.Left.Left = new TreeNode(2);
            //root.Left.Right = new TreeNode(1);
            //root.Left.Right.Left = new TreeNode(1);
            //root.Right = new TreeNode(-1);
            //root.Right.Left = new TreeNode(4);
            //root.Right.Left.Left = new TreeNode(1);
            //root.Right.Left.Right = new TreeNode(2);
            //root.Right.Right = new TreeNode(5);
            //root.Right.Right.Right = new TreeNode(2);

            //int k = 5;


            TreeNode root = new TreeNode(10);
            root.Left = new TreeNode(5);
            root.Left.Right = new TreeNode(2);
            root.Left.Right.Right = new TreeNode(1);
            root.Left.Left = new TreeNode(3);
            root.Left.Left.Left = new TreeNode(3);
            root.Left.Left.Right = new TreeNode(-2);
            root.Right = new TreeNode(-3);
            root.Right.Right = new TreeNode(11);

            int k = 8;

            Console.WriteLine(CountPathsWithSum(root, k));

            List<List<int>> lstResult = new List<List<int>>();
            AllPathsWithSum(root, k, lstResult);

            var r = GetAllPathsWithSum(root, k);

            Console.ReadLine();
        }

        private static List<List<int>> GetAllPathsWithSum(TreeNode root, int targetSum)
        {
            List<List<int>> lstResult = new List<List<int>>();

            if (root == null)
            {
                lstResult.Add(new List<int>());
                return lstResult;
            }

            GetAllPathsWithSum(root, targetSum, lstResult);
            GetAllPathsWithSum(root.Left, targetSum, lstResult);
            GetAllPathsWithSum(root.Right, targetSum, lstResult);

            return lstResult;
        }

        private static void GetAllPathsWithSum(TreeNode root, int targetSum, List<List<int>> lstResult)
        {
            if (root == null) return;

            List<int> lstCurrentPath = new List<int>();
            PopulatePathsWithSum(root, lstCurrentPath, targetSum, lstResult);
        }

        private static void PopulatePathsWithSum(TreeNode root, List<int> lstCurrentPath, int targetSum, List<List<int>> lstResult)
        {
            if (root == null) return;
            lstCurrentPath.Add(root.Data);

            if (lstCurrentPath.Sum() == targetSum)
                lstResult.Add(lstCurrentPath);            

            List<int> subPathLeft = new List<int>(lstCurrentPath);
            PopulatePathsWithSum(root.Left, subPathLeft, targetSum, lstResult);

            List<int> subPathRight = new List<int>(lstCurrentPath);
            PopulatePathsWithSum(root.Right, subPathRight, targetSum, lstResult);
        }

        private static void AllPathsWithSum(TreeNode root, int targetSum, List<List<int>> lstPath)
        {
            if (root == null) return;

            List<int> currentPath = new List<int>();
            GetPathsFromNode(root, currentPath, targetSum, 0, lstPath);

            AllPathsWithSum(root.Left, targetSum, lstPath);
            AllPathsWithSum(root.Right, targetSum, lstPath);
        }

        private static void GetPathsFromNode(TreeNode root, List<int> currentPath, int targetSum, int currentSum, List<List<int>> lstPath)
        {
            if (root == null) return;

            currentSum += root.Data;
            currentPath.Add(root.Data);

            if (currentSum == targetSum)
                lstPath.Add(currentPath);

            var subLeftPath = new List<int>(currentPath);
            GetPathsFromNode(root.Left, subLeftPath, targetSum, currentSum, lstPath);

            var subRightPath = new List<int>(currentPath);
            GetPathsFromNode(root.Right, subRightPath, targetSum, currentSum, lstPath);
        }

        private static int CountPathsWithSum(TreeNode root, int k)
        {
            if (root == null) return 0;

            int pathsFromRoot = CountPathIncludingNode(root, k, 0);

            return pathsFromRoot + CountPathsWithSum(root.Left, k) + CountPathsWithSum(root.Right, k);
        }

        private static int CountPathIncludingNode(TreeNode root, int targetSum, int currentSum)
        {
            if (root == null) return 0;

            int totalPaths = 0;
            currentSum += root.Data;

            if (currentSum == targetSum)
                totalPaths++;

            totalPaths += CountPathIncludingNode(root.Left, targetSum, currentSum);
            totalPaths += CountPathIncludingNode(root.Right, targetSum, currentSum);

            return totalPaths;
        }
    }
}
