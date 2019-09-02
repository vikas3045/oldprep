using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingStacks
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class Queue<T>
        {
            private Stack<T> stackForEnqueue;
            private Stack<T> stackForDequeue;

            public Queue()
            {
                stackForDequeue = new Stack<T>();
                stackForEnqueue = new Stack<T>();
            }

            public void Enqueue(T item)
            {
                stackForEnqueue.Push(item);
            }

            public T Dequeue()
            {
                if (stackForEnqueue.Count > 0)
                    return stackForDequeue.Pop();
                else
                {
                    while (stackForEnqueue.Count > 0)
                    {
                        stackForDequeue.Push(stackForEnqueue.Pop());
                    }

                    return stackForDequeue.Pop();
                }
            }
        }
    }
}
