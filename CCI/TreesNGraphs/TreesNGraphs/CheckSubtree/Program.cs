using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace CheckSubtree
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool CheckSubtree(TreeNode rootA, TreeNode rootB)
        {
            if (rootA == null && rootB == null)
                return true;
            else if (rootA == null || rootB == null)
                return false;

            if (rootA.Data == rootB.Data && IsIdentical(rootA, rootB))
                return true;
            else
                return CheckSubtree(rootA.Left, rootB) || CheckSubtree(rootA.Right, rootB);
        }

        private bool IsIdentical(TreeNode rootA, TreeNode rootB)
        {
            if (rootA == null && rootB == null)
                return true;
            else if (rootA == null || rootB == null)
                return false;

            if (rootA.Data != rootB.Data)
                return false;
            return IsIdentical(rootA.Left, rootB.Left) && IsIdentical(rootA.Right, rootB.Right);
        }
    }
}
