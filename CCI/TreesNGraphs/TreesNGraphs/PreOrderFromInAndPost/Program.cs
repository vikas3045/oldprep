using System;

namespace PreOrderFromInAndPost
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inOrder = { 4, 2, 5, 1, 3, 6 };
            int[] postOrder = { 4, 5, 2, 6, 3, 1 };

            int[] preOrder = PreOrderFromInAndPost(inOrder, 0, inOrder.Length - 1, postOrder, 0, postOrder.Length - 1);

            for (int i = 0; i < preOrder.Length; i++)
                Console.Write(preOrder[i] + ", ");

            Console.ReadLine();
        }

        private static int[] PreOrderFromInAndPost(int[] inOrder, int iStart, int iEnd, int[] postOrder, int pStart, int pEnd)
        {
            // Base condition
            if (iStart < iEnd)
            {
                int rootIndex = Array.IndexOf(inOrder, postOrder[pEnd]);

                // Rearrange the root and move left subtree elements by one
                for (int i = rootIndex; i >= iStart + 1; i--)
                {
                    inOrder[i] = inOrder[i - 1];
                }

                inOrder[iStart] = postOrder[pEnd];

                PreOrderFromInAndPost(inOrder, iStart + 1, rootIndex, postOrder, pStart, (rootIndex - (iStart + 1)));
                PreOrderFromInAndPost(inOrder, rootIndex + 1, iEnd, postOrder, rootIndex - iStart, pEnd - 1);

                return inOrder;
            }

            return null;
        }
    }
}
