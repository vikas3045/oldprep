using System;

namespace Stack
{
    public class Stack<T>
    {
        private StackNode _top;

        public void Push(T item)
        {
            StackNode node = new StackNode(item);
            node.Next = _top;
            _top = node;
        }

        public T Peek()
        {
            if (_top == null)
                throw new Exception("EmptyStackException");

            return _top.Data;
        }

        public T Pop()
        {
            if (_top == null)
                throw new Exception("EmptyStackException");

            T item = _top.Data;
            _top = _top.Next;

            return item;
        }

        public bool IsEmpty()
        {
            return _top == null;
        }

        public void Print()
        {
            var curr = _top;
            while (curr != null)
            {
                Console.Write(curr.Data + " ");
                curr = curr.Next;
            }
        }

        public class StackNode
        {
            public T Data { get; set; }
            public StackNode Next { get; set; }

            public StackNode(T data)
            {
                Data = data;
            }
        }
    }
}
