namespace Tree
{
    public class BinaryTreeNode
    {
        public int Data { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }

        public BinaryTreeNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
