using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class SimpleStack
    {
        private const int MAXSIZE = 1000;
        private int _top;
        private int[] _arr;

        private bool IsEmpty()
        {
            return _top < 0;
        }

        public SimpleStack()
        {
            _arr = new int[MAXSIZE];
            _top = -1;
        }

        public bool Push(int data)
        {
            if (_top < MAXSIZE)
            {
                _arr[++_top] = data;
                return true;
            }
            else
            {
                Console.WriteLine("Stack overflow.");
                return false;
            }
        }

        public int Pop()
        {
            if (_top < 0)
            {
                Console.WriteLine("Stack underflow.");
                return 0;
            }
            else
            {
                return _arr[_top--];
            }
        }

        public int Peek()
        {
            if (_top < 0)
            {
                Console.WriteLine("Stack underflow.");
                return 0;
            }
            else
            {
                return _arr[_top];
            }
        }

        public void Print()
        {
            if (_top < 0)
            {
                Console.WriteLine("Stack underflow.");
            }
            else
            {
                Console.WriteLine("Stack: ");
                for (int i = _top; i >= 0; i--)
                    Console.WriteLine(_arr[i]);
            }
        }
    }
}
