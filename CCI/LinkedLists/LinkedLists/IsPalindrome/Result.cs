using LinkedList;

namespace IsPalindrome
{
    internal class Result
    {
        internal bool result;
        internal ListNode node;

        public Result(ListNode node, bool v)
        {
            this.node = node;
            this.result = v;
        }
    }
}