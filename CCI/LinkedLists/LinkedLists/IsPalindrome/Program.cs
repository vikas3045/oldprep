using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 1, 2, 3, 1, 3, 2, 1 };

            LinkedList.LinkedList list = new LinkedList.LinkedList();

            for (int i = 0; i < input.Length; i++)
            {
                list.AddLast(new ListNode() { Data = input[i] });
            }
            Console.WriteLine(IsPalindromeRec(list.Head));
            //Console.WriteLine(IsPalindrome(list.Head));
            Console.ReadLine();
        }

        private static bool IsPalindromeRec(ListNode head)
        {
            int length = GetLength(head);
            Result p = IsPalindromeRec(head, length);
            return p.result;
        }

        private static Result IsPalindromeRec(ListNode head, int length)
        {
            if (head == null || length <= 0)
                return new Result(head, true);
            else if (length == 1)
                return new Result(head.Next, true);

            Result res = IsPalindromeRec(head.Next, length - 2);

            if (!res.result || res.node == null)
                return res;

            res.result = (head.Data == res.node.Data);

            res.node = res.node.Next;

            return res;
        }

        private static int GetLength(ListNode head)
        {
            int size = 0;
            while (head != null)
            {
                size++;
                head = head.Next;
            }
            return size;
        }

        private static bool IsPalindrome(ListNode head)
        {
            Stack<int> stack = new Stack<int>();
            ListNode current = head;
            while (current != null)
            {
                stack.Push(current.Data);
                current = current.Next;
            }

            current = head;

            while (current != null)
            {
                if (current.Data != stack.Pop())
                    return false;
                current = current.Next;
            }

            return true;
        }
    }
}
