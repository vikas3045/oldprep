using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace SerializeAndDeserialize
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

            var serializedTree = Serialize(root);
            Console.WriteLine(serializedTree);

            TreeNode deserializedTree = Deserialize(serializedTree);

            Console.ReadLine();
        }

        private static TreeNode Deserialize(string serializedTree)
        {
            if (String.IsNullOrWhiteSpace(serializedTree))
                return null;

            string[] arrNodes = serializedTree.Split(',');
            int curPos = 0;
            return Deserialize(arrNodes, ref curPos);
        }

        private static TreeNode Deserialize(string[] arrNodes, ref int curPos)
        {
            if (arrNodes == null)
                return null;

            if (curPos == arrNodes.Length || arrNodes[curPos] == "$" || String.IsNullOrWhiteSpace(arrNodes[curPos]))
            {
                curPos += 1;
                return null;
            }

            TreeNode root = new TreeNode();
            root.Data = int.Parse(arrNodes[curPos]);

            curPos += 1;

            root.Left = Deserialize(arrNodes, ref curPos);
            root.Right = Deserialize(arrNodes, ref curPos);

            return root;
        }

        private static string Serialize(TreeNode root)
        {
            StringBuilder serializedTree = new StringBuilder();

            SerializeHelper(root, serializedTree);

            return serializedTree.ToString(); ;
        }

        private static void SerializeHelper(TreeNode root, StringBuilder serializedTree)
        {
            if (root == null)
            {
                serializedTree.Append("$,");
                return;
            }

            serializedTree.Append(root.Data + ",");

            SerializeHelper(root.Left, serializedTree);
            SerializeHelper(root.Right, serializedTree);
        }

        //public static List<int> Serialize(TreeNode root)
        //{
        //    List<int> serializedNums = new List<int>();

        //    SerializeRecursively(root, serializedNums);

        //    return serializedNums;
        //}

        //private static void SerializeRecursively(TreeNode root, List<int> nums)
        //{
        //    if (root == null)
        //    {
        //        nums.Add(-1);
        //        return;
        //    }

        //    nums.Add(root.Data);
        //    SerializeRecursively(root.Left, nums);
        //    SerializeRecursively(root.Right, nums);
        //}

        //public static TreeNode Deserialize(List<int> serializedNums)
        //{
        //    DeserializedNode pair = DeserializeRecursively(serializedNums, 0);

        //    return pair.node;
        //}

        //private static DeserializedNode DeserializeRecursively(List<int> serializedNums, int start)
        //{
        //    int num = serializedNums[start];

        //    if (num == -1)
        //        return new DeserializedNode(null, start + 1);

        //    TreeNode node = new TreeNode(num);

        //    DeserializedNode p1 = DeserializeRecursively(serializedNums, start + 1);
        //    node.Left = p1.node;

        //    DeserializedNode p2 = DeserializeRecursively(serializedNums, p1.startIndex);
        //    node.Right = p2.node;

        //    return new DeserializedNode(node, p2.startIndex);
        //}

        //private class DeserializedNode
        //{
        //    public TreeNode node;
        //    public int startIndex;

        //    public DeserializedNode(TreeNode node, int index)
        //    {
        //        this.node = node;
        //        this.startIndex = index;
        //    }
        //}
    }
}
