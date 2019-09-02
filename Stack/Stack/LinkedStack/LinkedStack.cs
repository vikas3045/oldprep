using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class LinkedStack<T>
    {
        private ListNode<T> _head;
        private int _top;

        public LinkedStack()
        {
            _head = null;
            _top = -1;
        }

        public void Push(T data)
        {
            ListNode<T> elementToBeAdded = new ListNode<T>
            {
                Data = data,
                Next = _head
            };

            _head = elementToBeAdded;
            _top++;
        }

        public T Pop()
        {
            if (_top < 0)
            {
                Console.WriteLine("Stack underflow.");
                return default(T);
            }
            else
            {
                var value = _head.Data;
                _head = _head.Next;
                _top--;

                return value;
            }
        }

        public T Peek()
        {
            if (_top < 0)
            {
                Console.WriteLine("Stack underflow.");
                return default(T);
            }
            else
            {
                return _head.Data;
            }
        }

        public bool IsEmpty()
        {
            return _top < 0;
        }

        public void Print()
        {
            if (_top < 0)
            {
                Console.WriteLine("Stack underflow.");
            }
            else
            {
                var currentNode = _head;
                Console.WriteLine("Stack: ");
                while (currentNode != null)
                {
                    Console.WriteLine(currentNode.Data);
                    currentNode = currentNode.Next;
                }
            }
        }
    }

    public class ListNode<T>
    {
        public T Data { get; set; }
        public ListNode<T> Next { get; set; }
    }
}
