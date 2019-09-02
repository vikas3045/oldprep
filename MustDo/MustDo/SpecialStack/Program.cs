using System;
using System.Collections.Generic;

namespace SpecialStack
{
    class Program
    {
        static void Main(string[] args)
        {
            SpecialStack sp = new SpecialStack();
            sp.Push(5);

            Console.WriteLine(sp.Min());

            sp.Push(6);
            Console.WriteLine(sp.Min());

            sp.Push(3);
            Console.WriteLine(sp.Min());

            sp.Push(1);
            Console.WriteLine(sp.Min());

            sp.Pop();
            Console.WriteLine(sp.Min());

            Console.ReadLine();
        }
    }

    public class SpecialStack : Stack<int>
    {
        private Stack<int> minStack;

        public SpecialStack()
        {
            minStack = new Stack<int>();
        }

        public new void Push(int item)
        {
            base.Push(item);

            if (minStack.Count > 0)
            {
                if (item < minStack.Peek())
                {
                    minStack.Push(item);
                }
            }
            else
            {
                minStack.Push(item);
            }
        }

        public new int Pop()
        {
            var poppedItem = base.Pop();

            if (minStack.Peek() == poppedItem)
            {
                minStack.Pop();
            }

            return poppedItem;
        }

        public int Min()
        {
            if (minStack.Count > 0)
                return minStack.Peek();

            return -1;
        }
    }
}
