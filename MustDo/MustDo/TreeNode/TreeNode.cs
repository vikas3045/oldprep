﻿namespace Tree
{
    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode()
        {

        }

        public TreeNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public class TreeNodeWithParent
    {
        public int Data { get; set; }
        public TreeNodeWithParent Left { get; set; }
        public TreeNodeWithParent Right { get; set; }
        public TreeNodeWithParent Parent { get; set; }
        public TreeNodeWithParent() { }
        public TreeNodeWithParent(int data)
        {
            Data = data;
            Left = null;
            Right = null;
            Parent = null;
        }
    }
}
